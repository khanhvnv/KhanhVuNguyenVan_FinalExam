using Unsplash.Test.Services.Models;

namespace Unsplash.Test.Services.Data
{
    public class DataStorage
    {
        public static AsyncLocal<Dictionary<string, List<string>>> likeImage { get; set; } = new AsyncLocal<Dictionary<string, List<string>>>();
        public static AsyncLocal<Dictionary<string, List<CollectionResponseDto>>> createdCollection { get; set; } = new AsyncLocal<Dictionary<string, List<CollectionResponseDto>>>();
        public static AsyncLocal<string> apiCode = new AsyncLocal<string>();
        public static AsyncLocal<Dictionary<string, AccountDto>> accountList = new AsyncLocal<Dictionary<string, AccountDto>>();

        public static void InitData()
        {
            likeImage.Value = new Dictionary<string, List<string>>();
            createdCollection.Value = new Dictionary<string, List<CollectionResponseDto>>();
            accountList.Value = new Dictionary<string, AccountDto>();
        }
        public static void SetApiCode(string code)
        {
            apiCode.Value = code;
        }
        public static string GetApiCode()
        {
            return apiCode.Value;
        }
        public static void AddLikePhoto(string key, string photoId)
        {
            likeImage.Value[key].Add(photoId);
        }
        public static void AddLikePhotos(string key, List<string> photoIds)
        {
            if (likeImage.Value.ContainsKey(key))
                foreach (var photoId in photoIds)
                {
                    likeImage.Value[key].Add(photoId);
                }
            else
            {
                likeImage.Value.Add(key, photoIds);
            }
        }
        public static List<string> GetLikePhoto(string key)
        {
            if (likeImage.Value.ContainsKey(key))
                return likeImage.Value[key];
            return null;
        }
        public static List<string> GetLikePhoto(string key, int numberOfLikedPhotos = 0)
        {
            List<string> lstReturn = new List<string>();
            if (!string.IsNullOrEmpty(key))
            {
                var photoids = likeImage.Value[key];
                if (numberOfLikedPhotos > 0)
                    lstReturn.AddRange(photoids.Take(numberOfLikedPhotos));
                else
                    lstReturn.AddRange(photoids);
            }
            return lstReturn;
        }

        public static void ClearDataStore()
        {
            accountList.Value = null;
            createdCollection.Value = null;
        }
        public static void StoreToken(string accountKey, AccountDto account)
        {
            if (!accountList.Value.ContainsKey(accountKey))
                accountList.Value.Add(accountKey, account);
            else
                accountList.Value[accountKey] = account;
        }
        public static void StoreToken(Dictionary<string, AccountDto> accountList)
        {
            foreach (var account in accountList)
            {
                if (!accountList.ContainsKey(account.Key))
                    accountList.Add(account.Key, account.Value);
                else
                    accountList[account.Key].tokenId = account.Value.tokenId;
            }

        }
        public static void StoreAccount(Dictionary<string, AccountDto> accountList)
        {
            foreach (var account in accountList)
            {
                if (!accountList.ContainsKey(account.Key))
                    accountList.Add(account.Key, account.Value);
                else
                    accountList[account.Key] = account.Value;
            }

        }
        public static void StoreCollection(string accountKey, string collectionId)
        {
            if (!createdCollection.Value.ContainsKey(accountKey))
            {
                createdCollection.Value.Add(accountKey, new List<CollectionResponseDto> { new CollectionResponseDto() { id = collectionId } });
            }
            else
            {
                var lstCollections = createdCollection.Value[accountKey];
                if (lstCollections.Where(x => x != null && x.id == collectionId).Any()) { }
                else { lstCollections.Add(new CollectionResponseDto() { id = collectionId }); }
            }
        }
        public static void StoreCollection(string accountKey, CollectionResponseDto collection)
        {
            if (!createdCollection.Value.ContainsKey(accountKey))
            {
                createdCollection.Value.Add(accountKey, new List<CollectionResponseDto> { collection });
            }
            else
            {
                var lstCollections = createdCollection.Value[accountKey];
                if (lstCollections.Where(x => x != null && x.id == collection.id).Any()) { }
                else { lstCollections.Add(collection); }
            }
        }
        public static string GetToken(string accountKey)
        {
            return accountList.Value[accountKey].tokenId;
        }
        public static List<CollectionResponseDto> GetCollections(string accountKey)
        {
            return createdCollection.Value[accountKey];
        }
        public static CollectionResponseDto GetFirstCollection(string accountKey)
        {
            return createdCollection.Value[accountKey].FirstOrDefault();
        }
    }
}
