# -*- mode: python -*-

block_cipher = None


added_files = [('CONFIG.py', '.'),
               ('templates', 'templates'),
               ('static', 'static')]

import os
if os.path.exists('openslide'):
    added_files.append(('openslide', 'openslide'))
if os.path.exists('NDP.read'):
    added_files.append(('NDP.read', 'NDP.read'))

a = Analysis(['scan-quality-viewer.py'],
             pathex=[],
             binaries=[],
             datas=added_files,
             hiddenimports=[],
             hookspath=[],
             runtime_hooks=[],
             excludes=[],
             win_no_prefer_redirects=False,
             win_private_assemblies=False,
             cipher=block_cipher)
pyz = PYZ(a.pure, a.zipped_data,
             cipher=block_cipher)
exe = EXE(pyz,
          a.scripts,
          exclude_binaries=True,
          name='scan-quality-viewer',
          debug=False,
          strip=False,
          upx=True,
          console=True )
coll = COLLECT(exe,
               a.binaries,
               a.zipfiles,
               a.datas,
               strip=False,
               upx=True,
               name='scan-quality-viewer')
