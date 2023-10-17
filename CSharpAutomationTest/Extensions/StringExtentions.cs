using CSharpAutomationFramework.Core.Utilities;

namespace CSharpAutomationFramework.Core.Extensions
{
    public static class StringExtentions
    {
        public static string GetAbsolutePath(this string value)
        {
            string filePath = Path.Combine(DirectoryUtility.GetCurrentDirectoryPath(), value);
            if (File.Exists(filePath)) { return filePath; }
            return string.Empty;
        }
        public static string GetTextFromJsonFile(this string filePath)
        {
            return File.ReadAllText(filePath.GetAbsolutePath());
        }
    }
}
