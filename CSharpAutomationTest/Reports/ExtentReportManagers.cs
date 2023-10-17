using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CSharpAutomationFramework.Core.Utilities;
using OpenQA.Selenium;

namespace CSharpAutomationFramework.Core.Reports
{
    public class ExtentReportManagers
    {
        public static readonly string TestReport = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Report\\");
        public static readonly string ScreenShot = Path.Combine(DirectoryUtility.GetCurrentDirectoryPath(), "ScreenShot\\");

        //config image type
        public static class Config
        {
            public const string ImageType = "png";
        }
        public static ExtentReports extent;
        public ExtentSparkReporter htmlReporter;
        public static IWebDriver driver;

        public static ExtentReports ExtentReportManager()
        {
            if(extent== null) {
                extent = new ExtentReports();
                string filePath = TestReport;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                var htmlReporter = new ExtentSparkReporter($"{filePath}Test_Result.html");
                extent.AttachReporter(htmlReporter);
                return extent;
            }
            return extent;
            
        }
        public static string TakeScreenshot(IWebDriver drv, string filename="")
        {
            if (filename == "")
                filename = "Screenshot_" + DateTime.Now.ToString("h_mm_ss") + "."+ Config.ImageType;

            string path = ScreenShot;
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            Screenshot screenshot = ((ITakesScreenshot)drv).GetScreenshot();

            string filepath = path+ filename;
            screenshot.SaveAsFile(filepath, ScreenshotImageFormat.Png);
            return filepath;
        }
    }
}