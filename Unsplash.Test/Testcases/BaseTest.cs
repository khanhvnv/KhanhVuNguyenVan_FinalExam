using CSharpAutomationFramework.Core.Configs;
using CSharpAutomationFramework.Core.Reports;
using CSharpAutomationFramework.Core.Drivers;
using CSharpAutomationFramework.Core.Extensions;
using Unsplash.Test.Pages;
using Unsplash.Test.Services.Data;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Unsplash.Test.Services.Models;
using CSharpAutomationFramework.Core.API;
using Unsplash.Test.Services.Services;
using Unsplash.Test.Services;
using CSharpAutomationFramework.Core.Utilities;

namespace Unsplash.Test.Testcases
{
    [TestFixture]
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        protected HomePage homePage;
        protected Dictionary<string, AccountDto> _accountData;
        protected APIClient _apiClient;

        protected CollectionService _collectionServices;
        protected PhotoService _photoServices;
        protected AccountDto _defaultUser;
        protected string baseUrl;
        protected string baseApiUrl;
        protected string downloadFolder;
        protected string testcaseId;
        public BaseTest()
        {
            Application.Configure();
            _accountData = DataFileService.InitAccountData();
            _defaultUser = _accountData["default"];  
            baseUrl = Application.GetConfig()["application:baseUrl"];
            baseApiUrl = Application.GetConfig()["application:apiBaseUrl"];
            downloadFolder = Path.Combine(DirectoryUtility.GetCurrentDirectoryPath(), "download");

            _apiClient = new APIClient(baseApiUrl);
            _collectionServices = new CollectionService(_apiClient);
            _photoServices = new PhotoService(_apiClient);
            homePage = new HomePage();
        }

        [OneTimeSetUp]
        protected void Setup()
        {
            DataStorage.InitData();
            DataStorage.StoreToken(_accountData);
            ExtentTestManager.CreateParentTest(TestContext.CurrentContext.Test.ClassName);
        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            ExtentReportManagers.extent.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
            DriverManager.InitBrowser(new BrowserConfig()
            {
                Name = Application.GetConfig()["browser:name"],
                Version = Application.GetConfig()["browser:version"],
                UseRemote = string.Compare(Application.GetConfig()["browser:mode"], "remote") == 0,
                HubUrl = Application.GetConfig()["browser:remoteUrl"]
            }, downloadFolder);
            DriverManager.GetCurrentDriver().GoToUrl(baseUrl);
            testcaseId = TestContext.CurrentContext.Test.ID;
    }
        [TearDown]
        public void AfterTest()
        {
            UpdateTestStatus();
            DriverManager.QuitDriver();
            DataStorage.ClearDataStore();
        }

        public static void UpdateTestStatus()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logStatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    string filepath = ExtentReportManagers.TakeScreenshot(DriverManager.GetCurrentDriver());
                    ExtentTestManager.GetTest().Log(Status.Fail, "Message: " + TestContext.CurrentContext.Result.Message);
                    ExtentTestManager.GetTest().Log(Status.Fail, "Screenshot: " + filepath);
                    break;
                case TestStatus.Inconclusive:
                    logStatus = Status.Warning;
                    break;
                case TestStatus.Passed:
                    logStatus = Status.Pass;
                    break;
                default:
                    logStatus = Status.Pass;
                    break;

            }
            ExtentTestManager.GetTest().Log(logStatus, "Test ended with " + logStatus + stacktrace);
        }
        public async Task StoreTokenAsync(string accountKey, AccountDto account)
        {
            DataStorage.StoreToken(accountKey, account);
        }
        public string GetToken(string accountKey)
        {
            return DataStorage.GetToken(accountKey);
        }
        public void NavigateToPage(string url)
        {
            DriverManager.GetCurrentDriver().GoToUrl(url);
            DriverManager.GetCurrentDriver().Navigate().Refresh();
        }
    }
}