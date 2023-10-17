
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.Helpers;
using WebDriverManager.DriverConfigs.Impl;


namespace CSharpAutomationFramework.Core.Drivers.chrome
{
    public class LocalChromeDriver
    {
        //public LocalChromeDriver() { }
        public WebDriver Create(string version, string defaultDownloadFolder)
        {
            string driverExcuteableFilename =  new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser); 
            string driverPath = System.IO.Directory.GetParent(driverExcuteableFilename).FullName;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddUserProfilePreference("download.default_directory", defaultDownloadFolder);
            var service = ChromeDriverService.CreateDefaultService(driverPath);
            return new ChromeDriver(service, chromeOptions);
        }
    }
}
