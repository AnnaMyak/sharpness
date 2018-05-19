# Copyright (c) 2017 Pavlo Gotsonoga
# Based on https://github.com/openslide/openslide-python/blob/master/examples/deepzoom/deepzoom_multiserver.py.

import os
from collections import OrderedDict
from threading import Lock

import openslide
from openslide import OpenSlide
from openslide.deepzoom import DeepZoomGenerator

#from large_ndpi_deepzoom import LargeNDPiDeepZoomGenerator


class SlideCache(object):
    def __init__(self, cache_size, use_ndp_read, ndpi_size_limit, dz_opts):
        self.cache_size = cache_size
        self.use_ndp_read = use_ndp_read
        self.ndpi_size_limit = ndpi_size_limit
        self.dz_opts = dz_opts
        self._lock = Lock()
        self._cache = OrderedDict()

    def get(self, path):
        with self._lock:
            if path in self._cache:
                # Move to end of LRU
                slide = self._cache.pop(path)
                self._cache[path] = slide
                return slide

        if path.endswith('.ndpi') and self.use_ndp_read and os.path.getsize(path) >= self.ndpi_size_limit:
            slide = LargeNDPiDeepZoomGenerator(path, self.dz_opts['tile_size'], self.dz_opts['overlap'])
        else:
            osr = OpenSlide(path)
            slide = DeepZoomGenerator(osr, **self.dz_opts)
            try:
                mpp_x = osr.properties[openslide.PROPERTY_NAME_MPP_X]
                mpp_y = osr.properties[openslide.PROPERTY_NAME_MPP_Y]
                slide.mpp = (float(mpp_x) + float(mpp_y)) / 2
            except (KeyError, ValueError):
                slide.mpp = 0

        with self._lock:
            if path not in self._cache:
                if len(self._cache) == self.cache_size:
                    self._cache.popitem(last=False)
                self._cache[path] = slide
        return slide
