using CSharpAutomationFramework.Core.Extensions;
using CSharpAutomationFramework.Core.Utilities;
using Unsplash.Test.Services.Constants;
using Unsplash.Test.Services.Models;

namespace Unsplash.Test.Services.Services
{
    public class DataFileService
    {
        public static Dictionary<string, AccountDto> ReadAccountData()
        {
            Dictionary<string, AccountDto>  AccountData = new Dictionary<string, AccountDto>();

            string path = FileConstant.AccountFilePath.GetAbsolutePath();

            var accountList = JsonFileUtility.ReadAndParse<Dictionary<string, AccountDto>>(path);

            foreach (var item in accountList)
            {
                AccountData.Add(item.Key, item.Value);
            }

            return AccountData;
        }
    }
}
