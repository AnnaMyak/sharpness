# A server for viewing [virtual slides supported by OpenSlide](http://openslide.org/formats/) in browser.

## Prerequisites:
1. Install [Python](https://www.python.org/downloads/).
  * Please make sure you install _pip_ too.
  * Installing _py launcher_ will let you start Python files by double-clicking them.
2. Update _pip_ and _setuptools_:  
`python -m pip install -U pip`  
`pip install -U setuptools`
3. Install _Flask_ and _openslide-python_:  
`pip install Flask openslide-python`
4. Download [OpenSlide binaries](http://openslide.org/download/) and add them to _PATH_.
  * Alternatively you can create _.\openslide_ directory and copy binaries there, optionally [omitting some files](http://openslide.org/docs/windows/). In this case _PATH_ does not has to be modified.

## How to run and use it:
1. Edit _CONFIG.py_.
  * _SLIDE_DIR_ is the only parameter which necessarily has to be set. For example, _r'D:\slides'_.
2. Run the server:  
`python scan-quality-viewer.py`
  * You can also double-click _scan-quality-viewer.py_, if you have _py launcher_ installed.
3. Open a slide in browser.
  * Assuming that you have changed only _SLIDE_DIR_ parameter which now points to _D:\slides_, and the slide's path is _D:\slides\test\slide.mrxs_, open _http://localhost:5000/test/slide.mrxs_.

### How to add support for large NDPi files using NDP.read:
1. Create _.\NDP.read_ directory and copy _NDPRead.dll_ there.
2. Set _USE_NDP_READ_ to _True_ in _CONFIG.py_.

### How to freeze:
1. Install [PyInstaller](http://www.pyinstaller.org/):  
`pip install pyinstaller`
2. Run the following command:  
`pyinstaller scan-quality-viewer.spec`
3. Copy the _.\dist\scan-quality-viewer_ directory wherever you want.  
In order to start the server run _scan-quality-viewer.exe_.

#### The project was tested with following Python versions:
* Python 3.5
* Python 3.6

#### The project was tested with following versions of libraries:
* [Flask 0.12.2](https://pypi.python.org/pypi/Flask/0.12.2)
* [openslide-python 1.1.1](https://pypi.python.org/pypi/openslide-python/1.1.1)
* [OpenSlide binaries 2017-11-22](https://github.com/openslide/openslide-winbuild/releases/tag/v20171122)
* NDP.read 1.1.35

#### The projects contains following JavaScript libraries:
* [jQuery 3.3.1](http://blog.jquery.com/2018/01/20/jquery-3-3-1-fixed-dependencies-in-release-tag/)
* [OpenSeadragon 2.3.1](https://github.com/openseadragon/openseadragon/releases/tag/v2.3.1)
* [OpenSeadragonScalebar e30716c](https://github.com/usnistgov/OpenSeadragonScalebar/tree/e30716c06939e1dbccaeba7472ba1b98a1f047da)

Minified versions of jQuery and OpenSeadragon with configured [sourcemaps](https://www.html5rocks.com/en/tutorials/developertools/sourcemaps/) are used.