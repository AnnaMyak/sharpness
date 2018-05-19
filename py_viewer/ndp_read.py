# Copyright (c) 2018 Pavlo Gotsonoga

import os
import threading
import time
from ctypes import CDLL, c_long, c_void_p, c_wchar_p, POINTER, c_float, create_string_buffer, Structure, c_ulong, \
    sizeof, cast

NDPRead = CDLL(os.path.dirname(os.path.realpath(__file__)) + os.sep + 'NDP.read' + os.sep + 'NDPRead.dll')

c_long_p = POINTER(c_long)

GetMap = NDPRead.GetMapW
GetMap.argtypes = [c_wchar_p, c_long_p, c_long_p, c_long_p, c_long_p, c_void_p, c_long_p, c_long_p, c_long_p]
GetMap.restype = c_long

GetSourcePixelSize = NDPRead.GetSourcePixelSizeW
GetSourcePixelSize.argtypes = [c_wchar_p, c_long_p, c_long_p]
GetSourcePixelSize.restype = c_long

GetSourceLens = NDPRead.GetSourceLensW
GetSourceLens.argtypes = [c_wchar_p]
GetSourceLens.restype = c_float


class GetImageDataExParams(Structure):
    _fields_ = [('nSize', c_ulong), ('nPhysicalXPos', c_long), ('nPhysicalYPos', c_long), ('nPhysicalZPos', c_long),
                ('fMag', c_float), ('nPixelWidth', c_long), ('nPixelHeight', c_long), ('nPhysicalWidth', c_long),
                ('nPhysicalHeight', c_long), ('pBuffer', c_void_p), ('nBufferSize', c_long)]


GetImageDataEx = NDPRead.GetImageDataExW
GetImageDataEx.argtypes = [c_wchar_p, POINTER(GetImageDataExParams)]
GetImageDataEx.restype = c_long

CleanUp = NDPRead.CleanUp
CleanUp.restype = c_long


class Cleaner:
    def __init__(self, event, delay):
        self.event = event
        self.delay = delay
        thread = threading.Thread(target=self.run, name='Cleaner', daemon=True)
        thread.start()

    def run(self):
        while True:
            self.event.wait()
            self.clean()

    def clean(self):
        self.event.clear()
        time.sleep(self.delay)
        if not self.event.is_set():
            CleanUp()
        else:
            self.clean()


def get_physical_info(slide_path):
    physical_width_center = c_long()
    physical_height_center = c_long()
    physical_width = c_long()
    physical_height = c_long()
    GetMap(slide_path, physical_width_center, physical_height_center, physical_width, physical_height, None, c_long(),
           c_long(), c_long())
    return physical_width_center.value, physical_height_center.value, physical_width.value, physical_height.value


def get_source_pixel_size(slide_path):
    width = c_long()
    height = c_long()
    GetSourcePixelSize(slide_path, width, height)
    return width.value, height.value


def get_source_lens(slide_path):
    return GetSourceLens(slide_path)


def get_image_data(slide_path, x, y, level, w, h, x0, y0, width_ratio, height_ratio, lens):
    nm_per_width_pixel = width_ratio * (2 ** level)
    nm_per_height_pixel = height_ratio * (2 ** level)
    x_pos = c_long(round(x0 + (x / (2 ** level) + w / 2) * nm_per_width_pixel))
    y_pos = c_long(round(y0 + (y / (2 ** level) + h / 2) * nm_per_height_pixel))
    mag = c_float(lens / (2 ** level))
    params = GetImageDataExParams(nSize=sizeof(GetImageDataExParams), nPhysicalXPos=x_pos, nPhysicalYPos=y_pos,
                                  nPhysicalZPos=0, fMag=mag, nPixelWidth=w, nPixelHeight=h, pBuffer=None, nBufferSize=0)
    GetImageDataEx(slide_path, params)
    buffer = create_string_buffer(params.nBufferSize)
    params.pBuffer = cast(buffer, c_void_p)
    GetImageDataEx(slide_path, params)
    return buffer.raw
