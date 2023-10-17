namespace CSharpAutomationFramework.Core.Utilities
{
    public class DirectoryUtility
    {
        public static string GetCurrentDirectoryPath()
        {
            return Directory.GetCurrentDirectory();
        }
        public static bool CheckFileExist(string filePath)
        {
            return File.Exists(filePath);
        }
        public static bool CheckFolderExist(string folderPath)
        {
            return Directory.Exists(folderPath);
        }
        public static void ClearFolder(string folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                subDirectory.Delete(true);
            }
        }
    }
}
