@echo off
echo "Starting update"
taskkill /f /im schizo.exe
TIMEOUT 2
del "schizo.exe"
TIMEOUT 2
ren "update.exe" "schizo.exe"
TIMEOUT 2
start /d "%cd%" schizo.exe