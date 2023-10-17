using CSharpAutomationFramework.Core.API;
using RestSharp;
using Unsplash.Test.Services.Constants;
using Unsplash.Test.Services.Models;

namespace Unsplash.Test.Services
{
    public class CollectionService
    {
        private readonly APIClient _client;
        public CollectionService(APIClient client)
        {
            _client = client;
        }

        public async Task<RestResponse<CollectionResponseDto>> CreateCollection(CollectionRequestDto collection, string tokenId)
        {
            var res = await _client.CreateRequest(APIConstant.GetCreateCollectionEndPoint)
                .AddHeader("Content-Type", ContentType.Json)
                .AddHeader("Accept", ContentType.Json)
                .AddHeader("Authorization", "Bearer " + tokenId)
                .AddBody(collection)
                .ExecutePostAsync<CollectionResponseDto>();
            return res;
        }
        public async Task<RestResponse> DeleteCollection(string collectionId, string tokenId)
        {

            var res=await _client.CreateRequest(APIConstant.DeleteCollectionEndPoint(collectionId))
                .AddHeader("Content-Type", ContentType.Json)
                .AddHeader("Accept", ContentType.Json)
                .AddAuthorizationHeader("Bearer " + tokenId)
                .ExecuteDeleteAsync();
            return res;
        }
        public async Task<RestResponse> RemovePhotoFromCollection(PhotoCollectionRequestDto photoCollection, string tokenId)
        {
            return await _client.CreateRequest(APIConstant.DeletePhotoCollectionEndPoint(photoCollection.collection_id))
                .AddHeader("Content-Type", ContentType.Json)
                .AddHeader("Accept", ContentType.Json)
                .AddBody(photoCollection)
                .AddAuthorizationHeader("Bearer " + tokenId)
                .ExecuteDeleteAsync();
        }

    }
}
