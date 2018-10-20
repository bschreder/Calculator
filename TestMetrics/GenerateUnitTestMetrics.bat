REM   http://www.allenconway.net/2015/06/using-opencover-and-reportgenerator-to.html
REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"

REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0Calculator.Test.trx" del "%~dp0Calculator.Test.trx%"
IF EXIST "%~dp0Library.Test.trx" del "%~dp0Library.Test.trx%"

REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics

REM Generate the report output based on the test results
if %errorlevel% equ 0 ( 
	call :RunReportGeneratorOutput	
)

REM Launch the report
if %errorlevel% equ 0 ( 
	call :RunLaunchReport	
)
exit /b %errorlevel%


:RunOpenCoverUnitTestMetrics
REM run Calculator test metrics
"%~dp0..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"..\packages\xunit.runner.console.2.4.0\tools\net472\xunit.console.exe" ^
-targetargs:"..\Calculator.Test\bin\Debug\Calculator.Test.dll -xml .\GeneratedReports\Calculator.Test.xml" ^
-filter:"+[Calculator]* -[Calculator.Test*]* -[Calculator.Models*]* -[Library*]* -[*]Calculator.BundleConfig -[*]Calculator.FilterConfig -[*]Calculator.RouteConfig -[*]Calculator.WebApiApplication -[xunit*]*" ^
-mergebyhash ^
-skipautoprops ^
-showunvisited ^
-oldstyle ^
-output:"%~dp0\GeneratedReports\CalculatorTestReport.xml"

REM run Library and DbRepository test metrics
"%~dp0..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%~dp0..\packages\xunit.runner.console.2.4.0\tools\net472\xunit.console.exe" ^
-targetargs:"..\Library.Test\bin\Debug\Library.Test.dll -xml .\GeneratedReports\Library.Test.xml" ^
-filter:"+[Library]* -[Library.Test*]* +[DbRepository]* -[Calculator*]* -[xunit*]*" ^
-mergebyhash ^
-skipautoprops ^
-showunvisited ^
-oldstyle ^
-output:"%~dp0\GeneratedReports\LibraryTestReport.xml"
exit /b %errorlevel%


:RunReportGeneratorOutput
"%~dp0..\packages\ReportGenerator.3.1.2\tools\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\*TestReport.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGeneratorOutput"
exit /b %errorlevel%

:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGeneratorOutput\index.htm"
exit /b %errorlevel%
