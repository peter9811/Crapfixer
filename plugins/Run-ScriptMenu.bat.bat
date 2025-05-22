@echo off
:: Run-ScriptMenu.bat — one-UAC, loop-back launcher for *.ps1 files
:: Place this BAT next to your scripts and double-click.

rem ----------------- self-elevate once -----------------
>nul 2>&1 "%SystemRoot%\system32\cacls.exe" "%SystemRoot%\system32\config\system"
if errorlevel 1 (
  powershell -NoProfile -Command "Start-Process '%~f0' -Verb RunAs"
  exit /b
)

title Run PowerShell Script (Administrator)
setlocal EnableDelayedExpansion
cd /d "%~dp0"

:Build
  set "i=0"
  for /f "delims=" %%F in ('dir /b /a:-d "*.ps1" ^| sort') do (
      if !i! lss 9 (
        set /a i+=1
        set "script!i!=%%F"
      )
  )
  if !i! equ 0 (
     echo No .ps1 files found beside this BAT.
     pause & exit /b
  )
goto Menu

:Menu
  cls
  echo ---------------------------------------------
  echo   Run PowerShell Script   (admin session)
  echo ---------------------------------------------
  for /L %%N in (1,1,!i!) do echo    %%N. !script%%N!
  echo    0. Exit
  echo.

  choice /c 0123456789 /n /m "Pick number (0-Exit): "
  set /a idx=%errorlevel%-1
  if !idx! equ 0 exit /b
  if !idx! gtr !i! (
     echo Invalid choice – try again.
     timeout /t 1 >nul
     goto Menu
  )

  set "file=!script%idx%!"
  echo.
  echo === Running "!file!" …
  powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0!file!"
  echo -------------------------------------------------
  echo Done.  Press any key to return to the menu.
  pause >nul
goto Menu
