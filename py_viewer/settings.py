# Copyright (c) 2017 Pavlo Gotsonoga
# Based on https://github.com/openslide/openslide-python/blob/master/examples/deepzoom/deepzoom_multiserver.py.

import os

from slide_cache import SlideCache


class Settings:
    def __init__(self, config):
        self.slide_dir = os.path.abspath(config['SLIDE_DIR'])
        config_map = {
            'DEEPZOOM_TILE_SIZE': 'tile_size',
            'DEEPZOOM_OVERLAP': 'overlap',
            'DEEPZOOM_LIMIT_BOUNDS': 'limit_bounds',
        }
        opts = dict((v, config[k]) for k, v in config_map.items())
        slide_cache_size = config['SLIDE_CACHE_SIZE']
        if slide_cache_size < 1:
            slide_cache_size = 1
        self.cache = SlideCache(slide_cache_size, config['USE_NDP_READ'], config['NDPI_SIZE_LIMIT'], opts)
        self.clean_up_delay = config['CLEAN_UP_DELAY']
        self.sharpness_map_dir = config['SHARPNESS_MAP_DIR']
        self.sharpness_map_extensions = config['SHARPNESS_MAP_EXTENSIONS'].split(', ')
