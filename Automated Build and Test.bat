@ECHO OFF
REM ---------------------------
REM       Configuration
REM Configure the following setting in order 
REM to make to script work properly
REM ---------------------------
REM Visual Studio Dev Enviroment Command Path (varies depending on the Version of Visual Studio you have Installed)
call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat"

REM The path where the .sln file is saved
SET SolutionFolder=C:\Users\Paulo\Documents\visual studio 2013\Projects\GFTInterview
ECHO %SolutionFolder%

REM Script itself

SET SolutionPath="%SolutionFolder%/GFTInterview.sln"
rem ECHO %SolutionPath%
SET TestContainerParameter=/testcontainer:"%SolutionFolder%\Domain.Test\bin\Debug\Domain.Test.dll"
rem ECHO %TestContainerParameter%

msbuild %SolutionPath% /t:Rebuild /p:Configuration=Debug && mstest %TestContainerParameter%