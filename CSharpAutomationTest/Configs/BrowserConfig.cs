namespace CSharpAutomationFramework.Core.Configs
{
    public class BrowserConfig
    {
        public string Name { get; set; }

        public string Version {  get; set; }    

        public bool UseRemote { get; set; }

        public string Platform { get; set; }

        public string HubUrl { get; set; }

        public int RequestRemoteWebDriverTimeoutMinutes { get; set; }

        public int PageLoadTimeoutSeconds { get; set; }

        public int ImplicitWaitSeconds { get; set; }
    }
}
