# Copyright (c) 2018 Pavlo Gotsonoga
# Based on https://github.com/openslide/openslide-python/blob/master/openslide/deepzoom.py.

from __future__ import division

import math
from io import BytesIO
from xml.etree.ElementTree import ElementTree, Element, SubElement

from PIL import Image

from ndp_read import get_source_pixel_size, get_source_lens, get_physical_info, get_image_data


def compute_level_count(lens):
    return int(math.log2(lens / 0.078125) + 1)


def get_best_level_for_downsample(level_downsamples, downsample):
    if downsample < level_downsamples[0]:
        return 0
    for i in range(1, len(level_downsamples)):
        if downsample < level_downsamples[i]:
            return i - 1
    return len(level_downsamples) - 1


def create_image_from_bytes(width, height, bytes_object, extra_width_pixel_present):
    image = Image.frombytes('RGB', (width, height), bytes_object)
    blue, green, red = image.split()
    image = Image.merge('RGB', (red, green, blue))
    image = image.transpose(Image.FLIP_TOP_BOTTOM)

    if extra_width_pixel_present:
        image = image.crop((0, 0, width - 1, height))

    return image


class LargeNDPiDeepZoomGenerator(object):
    def __init__(self, slide_path, tile_size=254, overlap=1):
        self._slide_path = slide_path
        physical_w_center, physical_h_center, physical_w, physical_h = get_physical_info(slide_path)
        self._x0 = physical_w_center - physical_w / 2
        self._y0 = physical_h_center - physical_h / 2
        width, height = get_source_pixel_size(slide_path)
        self._width_ratio = physical_w / width
        self._height_ratio = physical_h / height
        self._lens = get_source_lens(slide_path)

        self.mpp = (self._width_ratio + self._height_ratio) / 2 * 0.001

        # We have four coordinate planes:
        # - Row and column of the tile within the Deep Zoom level (t_)
        # - Pixel coordinates within the Deep Zoom level (z_)
        # - Pixel coordinates within the slide level (l_)
        # - Pixel coordinates within slide level 0 (l0_)

        self._z_t_downsample = tile_size
        self._z_overlap = overlap

        # Precompute dimensions
        # Slide level and offset
        level_count = compute_level_count(self._lens)
        self._l_dimensions = [(int(width / (2 ** i)), int(height / (2 ** i))) for i in range(0, level_count)]
        self._l0_offset = (0, 0)
        self._l0_dimensions = self._l_dimensions[0]
        # Deep Zoom level
        z_size = self._l0_dimensions
        z_dimensions = [z_size]
        while z_size[0] > 1 or z_size[1] > 1:
            z_size = tuple(max(1, int(math.ceil(z / 2))) for z in z_size)
            z_dimensions.append(z_size)
        self._z_dimensions = tuple(reversed(z_dimensions))
        # Tile
        tiles = lambda z_lim: int(math.ceil(z_lim / self._z_t_downsample))
        self._t_dimensions = tuple((tiles(z_w), tiles(z_h))
                                   for z_w, z_h in self._z_dimensions)

        # Deep Zoom level count
        self._dz_levels = len(self._z_dimensions)

        # Total downsamples for each Deep Zoom level
        l0_z_downsamples = tuple(2 ** (self._dz_levels - dz_level - 1)
                                 for dz_level in range(self._dz_levels))

        # Preferred slide levels for each Deep Zoom level
        level_downsamples = [2.0 ** (i - 1) for i in range(1, level_count + 1)]
        self._slide_from_dz_level = tuple(
            get_best_level_for_downsample(level_downsamples, d) for d in l0_z_downsamples)

        # Piecewise downsamples
        self._l0_l_downsamples = level_downsamples
        self._l_z_downsamples = tuple(
            l0_z_downsamples[dz_level] /
            self._l0_l_downsamples[self._slide_from_dz_level[dz_level]]
            for dz_level in range(self._dz_levels))

    def __repr__(self):
        return '%s(%r, tile_size=%r, overlap=%r)' % (
            self.__class__.__name__, self._slide_path, self._z_t_downsample, self._z_overlap)

    @property
    def level_count(self):
        return self._dz_levels

    @property
    def level_tiles(self):
        return self._t_dimensions

    @property
    def level_dimensions(self):
        return self._z_dimensions

    @property
    def tile_count(self):
        return sum(t_cols * t_rows for t_cols, t_rows in self._t_dimensions)

    def get_tile(self, level, address):
        # Read tile
        args, z_size = self._get_tile_info(level, address)
        l0_location, slide_level, l_size = args
        x, y = l0_location
        w, h = l_size
        bytes_object = get_image_data(self._slide_path, x, y, slide_level, w, h, self._x0, self._y0, self._width_ratio,
                                      self._height_ratio, self._lens)
        extra_width_pixel_present = False
        if len(bytes_object) > w * h * 3:
            extra_width_pixel_present = True
            w += 1
        tile = create_image_from_bytes(w, h, bytes_object, extra_width_pixel_present)

        # Scale to the correct size
        if tile.size != z_size:
            tile.thumbnail(z_size, Image.ANTIALIAS)

        return tile

    def _get_tile_info(self, dz_level, t_location):
        # Check parameters
        if dz_level < 0 or dz_level >= self._dz_levels:
            raise ValueError("Invalid level")
        for t, t_lim in zip(t_location, self._t_dimensions[dz_level]):
            if t < 0 or t >= t_lim:
                raise ValueError("Invalid address")

        # Get preferred slide level
        slide_level = self._slide_from_dz_level[dz_level]

        # Calculate top/left and bottom/right overlap
        z_overlap_tl = tuple(self._z_overlap * int(t != 0)
                             for t in t_location)
        z_overlap_br = tuple(self._z_overlap * int(t != t_lim - 1)
                             for t, t_lim in
                             zip(t_location, self.level_tiles[dz_level]))

        # Get final size of the tile
        z_size = tuple(min(self._z_t_downsample,
                           z_lim - self._z_t_downsample * t) + z_tl + z_br
                       for t, z_lim, z_tl, z_br in
                       zip(t_location, self._z_dimensions[dz_level],
                           z_overlap_tl, z_overlap_br))

        # Obtain the region coordinates
        z_location = [self._z_from_t(t) for t in t_location]
        l_location = [self._l_from_z(dz_level, z - z_tl)
                      for z, z_tl in zip(z_location, z_overlap_tl)]
        # Round location down and size up, and add offset of active area
        l0_location = tuple(int(self._l0_from_l(slide_level, l) + l0_off)
                            for l, l0_off in zip(l_location, self._l0_offset))
        l_size = tuple(int(min(math.ceil(self._l_from_z(dz_level, dz)),
                               l_lim - math.ceil(l)))
                       for l, dz, l_lim in
                       zip(l_location, z_size, self._l_dimensions[slide_level]))

        # Return read_region() parameters plus tile size for final scaling
        return (l0_location, slide_level, l_size), z_size

    def _l0_from_l(self, slide_level, l):
        return self._l0_l_downsamples[slide_level] * l

    def _l_from_z(self, dz_level, z):
        return self._l_z_downsamples[dz_level] * z

    def _z_from_t(self, t):
        return self._z_t_downsample * t

    def get_tile_coordinates(self, level, address):
        return self._get_tile_info(level, address)[0]

    def get_tile_dimensions(self, level, address):
        return self._get_tile_info(level, address)[1]

    def get_dzi(self, deepzoom_format):
        image = Element('Image', TileSize=str(self._z_t_downsample),
                        Overlap=str(self._z_overlap), Format=deepzoom_format,
                        xmlns='http://schemas.microsoft.com/deepzoom/2008')
        w, h = self._l0_dimensions
        SubElement(image, 'Size', Width=str(w), Height=str(h))
        tree = ElementTree(element=image)
        buf = BytesIO()
        tree.write(buf, encoding='UTF-8')
        return buf.getvalue().decode('UTF-8')
