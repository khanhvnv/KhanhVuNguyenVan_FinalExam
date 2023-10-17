using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CSharpAutomationFramework.Core.Drivers.firefox
{
    internal class RemoteFirefoxDriver
    {
        private string remoteUrl;
        public RemoteFirefoxDriver(string remoteUrl)
        {
            this.remoteUrl = remoteUrl;
        }
        public WebDriver Create()
        {
            return new RemoteWebDriver(new Uri(this.remoteUrl), new FirefoxOptions().ToCapabilities(), TimeSpan.FromMinutes(1));
        }
    }
}
