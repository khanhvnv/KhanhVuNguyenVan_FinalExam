[Name] 
[T-shaped Automation Testing | 2023 | B2 - Advanced] Selenium C# Practice with Second AUT

[Install]
Install Visual Studio Code,the latest update (1.83.1)
Language Install: .Net Core SDK
Next, install the extensions: C# & C# Dev Kit, Nuget Package Manage, and .NET Core Test Explorer
Then, install .NET 6.0 Runtime (https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-6.0.23-windows-x64-installer)
Restart to apply new install extensions.

[Browsers] 
Currently: run for the current version of Chrome, latest version of Firefox
If user wants to switch to run on Firefox, need to copy the 'browser' content of 'appsettingsFirefox.json' file to 'appsettingsFirefox.json' file

[How to run the test case(s)]
    - Execute a single test case:
    example:  dotnet test Unsplash.Test\bin\Debug\net6.0\Unsplash.Test.dll --filter Name~UnlikeListLikedPhotoSuccessfully

    - Execute multiple test cases:
    example:  dotnet test Unsplash.Test\bin\Debug\net6.0\Unsplash.Test.dll

[Trainer]
truong.nguyennhat1@nashtechglobal.com

[Contributor]
khanh.vunguyenvan@nashtechglobal.com

[Project status]
Development is keep going. 