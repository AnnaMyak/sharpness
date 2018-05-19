# Please note that this is a Python file.

HOST = '0.0.0.0'  # If set to '0.0.0.0', all public IPs are listened on. See https://goo.gl/zga5y3 for details.
PORT = 5000

SLIDE_DIR = r'C:\Users\AnnaToshiba2\Desktop\WSI'
SLIDE_CACHE_SIZE = 10

DEEPZOOM_FORMAT = 'jpeg'  # 'jpeg' or 'png' only.
DEEPZOOM_TILE_QUALITY = 95  # Applies to 'jpeg' only. See 'quality' option at https://goo.gl/cWqUJD.

# See https://goo.gl/Nx32iK.
DEEPZOOM_TILE_SIZE = 256
DEEPZOOM_OVERLAP = 0  # When using NDP.read please set this value to 0. Otherwise some errors might occur.
DEEPZOOM_LIMIT_BOUNDS = False  # Applies only to slides opened with OpenSlide. The value is ignored by NDP.read.

SHARPNESS_MAP_DIR = r''
SHARPNESS_MAP_EXTENSIONS = '.jpeg, .png, .Png'  # Every extension must start with a dot and be separated by ', '.

USE_NDP_READ = False
NDPI_SIZE_LIMIT = 4_000_000_000  # NDPi file size limit in bytes at which NDP.read is used instead of OpenSlide.
CLEAN_UP_DELAY = 60  # Delay in seconds after the last access to files via NDP.read before calling CleanUp().
