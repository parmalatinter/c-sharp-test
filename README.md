## C# TEST FOR .NET CORE 5.0

### C# UNIT TEST

### C# FAKES TEST

### C# DB(Postgres) TEST

### C# Http Post(Ajax) TEST

### C# SCRAPING TEST

### C# FORM TEST

### C# MUSIC TEST(ENDING MUSIC)

### CONSOLE BUILD
MSBuild ConsoleApp.sln /t:clean;rebuild /p:configuration=Debug;platform=x64

### CONSOLE TEST
vstest.console UnitTestProject\bin\Debug\net5.0-windows7.0\UnitTestProject.dll /platform:x64 /inIsolation

### CONSOLE TEST(WITH COVERAGE) CAN NOT WORK AT FAKE TEST
vstest.console UnitTestProject\bin\Debug\net5.0-windows7.0\UnitTestProject.dll /platform:x64 /inIsolation /EnableCodeCoverage
