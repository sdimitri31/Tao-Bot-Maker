@ECHO OFF
set version="0.6.0"
@REM set version=%1

cd "Tao Bot Maker"\bin\Release

xcopy /Y ..\..\..\README.txt
xcopy /Y C:\ImageSearchDLL.dll

del *.pdb *.config *.zip

tar -acvf ..\..\..\TaoBotMaker_v%version%.zip *

cd ..\..\..