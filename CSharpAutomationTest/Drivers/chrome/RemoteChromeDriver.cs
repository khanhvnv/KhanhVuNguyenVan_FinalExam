using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;


namespace CSharpAutomationFramework.Core.Drivers.chrome
{
    public class RemoteChromeDriver
    {
        private string remoteUrl;
        public RemoteChromeDriver(string remoteUrl)
        {
            this.remoteUrl = remoteUrl;
        }
        public WebDriver Create()
        {
            return new RemoteWebDriver(new Uri(this.remoteUrl), new ChromeOptions().ToCapabilities(), TimeSpan.FromMinutes(1));
        }
    }
}
