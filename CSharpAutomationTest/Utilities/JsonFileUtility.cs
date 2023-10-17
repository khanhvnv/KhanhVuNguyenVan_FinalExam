using Newtonsoft.Json;


namespace CSharpAutomationFramework.Core.Utilities
{
    public class JsonFileUtility
    {
        public static string ReadJsonFile(string path)
        {
            if (!Directory.Exists(path))
            {   
                path = Path.Combine(DirectoryUtility.GetCurrentDirectoryPath(),path);
                if (!File.Exists(path))
                    throw new Exception("Cannot find file " + path );
                
            }
            
            return File.ReadAllText(path);
        }
        public static T ReadAndParse<T>(string path) where T : class
        {
            var jsonContent = ReadJsonFile(path);
            var result = JsonConvert.DeserializeObject<T>(jsonContent);
            return result ;
        }
    }
}
