namespace CSharpAutomationFramework.Core.Reports
{
    public class ReportLog
    {
        public static void Pass(string message)
        {
            ExtentTestManager.GetTest().Pass(message);
        }
        public static void Fail(string message)
        {
            ExtentTestManager.GetTest().Fail(message);
        }
        public static void Skip(string message)
        {
            ExtentTestManager.GetTest().Skip(message);
        }

        public static void Info(string v)
        {
            ExtentTestManager.GetTest().Info(v);
        }
    }
}