@echo off
setlocal

for /f "delims=" %%G in ('"%ProgramFiles(x86)%\Microsoft Visual Studio\installer\vswhere.exe" -latest -property installationPath') do (
    set "VSCMD=%%G\Common7\Tools\VsDevCmd.bat"
)

call "%VSCMD%"

call git clean -fdx
call msbuild SciChartTest.sln /m /v:m /p:Configuration=Release /p:TargetFramework=net472 /restore
dotnet publish -f net8.0-windows -c Release
dotnet publish -f net9.0-windows -c Release
