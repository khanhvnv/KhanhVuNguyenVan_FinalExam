using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace CSharpAutomationFramework.Core.Drivers.firefox
{
    public class LocalFirefoxDriver
    {
        public WebDriver Create(string version, string defaultDownloadFolder)
        {
            string driverExcuteableFilename = new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.Latest);
            string driverPath = System.IO.Directory.GetParent(driverExcuteableFilename).FullName;
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddAdditionalOption("browser.download.dir", defaultDownloadFolder);
            var service = FirefoxDriverService.CreateDefaultService(driverPath);
            return new FirefoxDriver(service, firefoxOptions);
        }
    }
}
