# Copyright (c) 2017 Pavlo Gotsonoga
# Based on https://github.com/openslide/openslide-python/blob/master/examples/deepzoom/deepzoom_multiserver.py.

import os
import threading
from io import BytesIO

from flask import Flask, abort, make_response, render_template, url_for, send_file, request
from openslide import OpenSlideError

#from large_ndpi_deepzoom import LargeNDPiDeepZoomGenerator
#from ndp_read import Cleaner
from settings import Settings

app = Flask(__name__)
app.config.from_pyfile('CONFIG.py')

settings = Settings(app.config)

ndp_read_used_event = threading.Event()
#cleaner = Cleaner(ndp_read_used_event, settings.clean_up_delay)


def _get_absolute_path(path, directory):
    absolute_path = os.path.abspath(os.path.join(directory, path))
    if not absolute_path.startswith(directory + os.path.sep):
        # Directory traversal
        abort(404)
    if not os.path.exists(absolute_path):
        abort(404)
    return absolute_path


def _get_slide(path):
    absolute_path = _get_absolute_path(path, settings.slide_dir)
    try:
        slide = settings.cache.get(absolute_path)
        slide.filename = os.path.basename(absolute_path)
        return slide
    except OpenSlideError:
        abort(404)


@app.route('/<path:path>')
def process_file(path):
    if path.endswith(tuple(settings.sharpness_map_extensions)):
        absolute_path = _get_absolute_path(path, settings.sharpness_map_dir)
        return send_file(absolute_path, as_attachment=True)
    else:
        slide = _get_slide(path)
        slide_url = url_for('process_dzi', path=path)
        heatmap_url = request.args.get('heatmap_url')
        if heatmap_url is None:
            heatmap_url = ''
        return render_template('slide.html', slide_url=slide_url, slide_filename=slide.filename, slide_mpp=slide.mpp,
                               heatmap_url=heatmap_url)


@app.route('/<path:path>.dzi')
def process_dzi(path):
    slide = _get_slide(path)
    deepzoom_format = app.config['DEEPZOOM_FORMAT']
    resp = make_response(slide.get_dzi(deepzoom_format))
    resp.mimetype = 'application/xml'
    return resp


@app.route('/<path:path>_files/<int:level>/<int:col>_<int:row>.<deepzoom_format>')
def process_tile(path, level, col, row, deepzoom_format):
    slide = _get_slide(path)
    #if isinstance(slide, LargeNDPiDeepZoomGenerator) and not ndp_read_used_event.is_set():
     #   ndp_read_used_event.set()
    deepzoom_format = deepzoom_format.lower()
    if deepzoom_format != 'jpeg' and deepzoom_format != 'png':
        # Not supported by Deep Zoom
        abort(404)
    try:
        tile = slide.get_tile(level, (col, row))
        buf = BytesIO()
        tile.save(buf, deepzoom_format, quality=app.config['DEEPZOOM_TILE_QUALITY'])
        resp = make_response(buf.getvalue())
        resp.mimetype = 'image/%s' % deepzoom_format
        return resp
    except ValueError:
        # Invalid level or coordinates
        abort(404)


def run():
    app.run(host=app.config['HOST'], port=app.config['PORT'], threaded=True)
