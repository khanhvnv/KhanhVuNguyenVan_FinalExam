using OpenQA.Selenium;
using CSharpAutomationFramework.Core.Drivers.chrome;
using CSharpAutomationFramework.Core.Drivers.firefox;
using CSharpAutomationFramework.Core.Configs;


namespace CSharpAutomationFramework.Core.Drivers
{
    public class DriverManager
    {
        private static AsyncLocal<WebDriver> driver = new AsyncLocal<WebDriver>();
       
        public static void InitBrowser(BrowserConfig browserConfig, string downloadFolder)
        {
            WebDriver newDriver = null;
            if (browserConfig.UseRemote)
            {
                switch (browserConfig.Name.ToLower())
                {
                    case "chrome":
                        newDriver = new RemoteChromeDriver(browserConfig.HubUrl).Create();
                        break;
                    case "firefox":
                        newDriver = new RemoteFirefoxDriver(browserConfig.HubUrl).Create();
                        break;
                }
            }
            else
            {
                switch (browserConfig.Name.ToLower())
                {
                    case "chrome":
                        newDriver = new LocalChromeDriver().Create(browserConfig.Version, downloadFolder);
                        break;
                    case "firefox":
                        newDriver = new LocalFirefoxDriver().Create(browserConfig.Version, downloadFolder);
                        break;
                }
            }
            if (newDriver == null)
                throw new Exception(browserConfig.Name+ " browser is not supported");
            newDriver.Manage().Window.Maximize();
            driver.Value = newDriver;
        }
        public static WebDriver GetCurrentDriver()
        {
            return driver.Value;
        }

        public static void SwitchToLatestBrowser()
        {
            driver.Value.SwitchTo().Window(driver.Value.WindowHandles.Last());
        }

        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
            }
        }
    }
}
