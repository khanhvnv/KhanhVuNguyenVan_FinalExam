using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace CSharpAutomationFramework.Core.Configs
{
    public class Application
    {
        private static IConfigurationRoot config = null;
        public static IConfigurationRoot Configure()
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            config = configBuilder.Build();
            return config;
        }

        public static IConfigurationRoot GetConfig()
        {
            return config;
        }
    }
}
