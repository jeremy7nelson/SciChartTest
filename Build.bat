@echo off
setlocal

for /f "delims=" %%G in ('"%ProgramFiles(x86)%\Microsoft Visual Studio\installer\vswhere.exe" -latest -property installationPath') do (
    set "VSCMD=%%G\Common7\Tools\VsDevCmd.bat"
)

call "%VSCMD%"

call git submodule sync
call git submodule update --init --recursive
call git clean -fdx
call git submodule foreach git clean -fdx
call msbuild SciChartTest.sln /m /v:m /p:Configuration=Release /p:TargetFramework=net462 /restore
dotnet publish -f netcoreapp3.1 -c Release
dotnet publish -f net6.0-windows -c Release
