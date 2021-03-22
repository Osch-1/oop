@echo off

SET Program="%~1"

if %Program%=="" (
	echo Specify path to program
	exit /B 1
)

rem empty file doesnt break program
%Program% empty.txt > "%TEMP%\output.txt"
if NOT ERRORLEVEL 1 goto paramsHandleError
fc empty-file-result.txt "%TEMP%\output.txt" || goto emptyTestErr

rem empty file doesnt break program
%Program% incorrect-symbols.txt > "%TEMP%\output.txt"
if NOT ERRORLEVEL 1 goto paramsHandleError
fc incorrect-symbols-result.txt "%TEMP%\output.txt" || goto incorrectSymbolsTestErr

rem if provided matrix with 0 determinant program swill print a msg about it
%Program% zero-determinant.txt > "%TEMP%\output.txt"
if NOT ERRORLEVEL 0 goto paramsHandleError
fc zero-determinant-result.txt "%TEMP%\output.txt" || goto zeroDeterminantMatrixTestErr

rem program handles correct input
%Program% correct-input.txt > "%TEMP%\output.txt"
if ERRORLEVEL 1 goto paramsHandleError
fc correct-input-result.txt "%TEMP%\output.txt" || goto correctInputTestFailed

rem program ignores additional symbols in columns and lines
%Program% additional-symbols.txt > "%TEMP%\output.txt"
if ERRORLEVEL 1 goto paramsHandleError
fc additional-symbols-result.txt "%TEMP%\output.txt" || goto additionalSymbolsTestFailed

rem incorrect matrix format makes program print msg
%Program% "incorrect-matrix-format.txt" > "%TEMP%\output.txt"
if NOT ERRORLEVEL 1 goto paramsHandleError
fc incorrect-matrix-format-result.txt "%TEMP%\output.txt" || goto incorrectMatrixFormatTestFailed

rem all tests passed
echo All tests passed successfully
exit /B 0

rem Couldnt handle params
:paramsHandleError
echo Couldnt handle input params
exit /B 1

rem empty test failed
:emptyTestErr
echo  Couldnt handle empty file
exit /B 1

rem incorrect symbols test failed
:incorrectSymbolsTestErr
echo Couldnt handle file with incorrect symbols
exit /B 1

rem zero determinant test failed
:zeroDeterminantMatrixTestErr
echo Zero determinant test failed
exit /B 1

rem additional symbols test failed
:additionalSymbolsTestFailed
echo Additional symbols test failed
exit /B 1

rem incorrect matrix format test failed
:incorrectMatrixFormatTestFailed
echo Incorrect matrix format test failed
exit /B 1