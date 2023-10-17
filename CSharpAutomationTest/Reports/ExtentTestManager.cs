using AventStack.ExtentReports;
using System.Runtime.CompilerServices;

namespace CSharpAutomationFramework.Core.Reports
{
    public class ExtentTestManager
    {
        [ThreadStatic]
        private static ExtentTest parentTest;
        //[ThreadStatic] use ThreadStatic here -> fail in other thread
        private static AsyncLocal<ExtentTest> childTest = new AsyncLocal<ExtentTest>();
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        {
            parentTest = ExtentReportManagers.ExtentReportManager().CreateTest(testName, description);
            return parentTest;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, string description = null)
        {
            childTest.Value = parentTest.CreateNode(testName, description);
            return childTest.Value;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest() {
            return childTest.Value;
        }
    }
}
