# Copyright (c) 2017 Pavlo Gotsonoga

import os

os.environ['PATH'] = os.path.dirname(os.path.realpath(__file__)) + os.sep + 'openslide' + os.pathsep + os.environ[
    'PATH']
