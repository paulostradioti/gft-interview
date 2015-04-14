SET %DevEnv% "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat"

call %DevEnv% msbuild "C:\Users\Paulo\Documents\visual studio 2013\Projects\GFTInterview\GFTInterview.sln" /t:Rebuild /p:Configuration=Debug && mstest  /testcontainer:"C:\Users\Paulo\Documents\Visual Studio 2013\Projects\GFTInterview\Domain.Test\bin\Debug\Domain.Test.dll"