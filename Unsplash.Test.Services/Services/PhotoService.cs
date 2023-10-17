using CSharpAutomationFramework.Core.API;
using RestSharp;
using Unsplash.Test.Services.Constants;
using Unsplash.Test.Services.Models;

namespace Unsplash.Test.Services.Services
{
    public class PhotoService
    {
        private readonly APIClient _client;
        public PhotoService(APIClient client)
        {
            _client = client;
        }

        public async Task<RestResponse<List<GetAllPhotosDto>>> GetAllPhotos(string tokenId)
        {
            var res = await _client.CreateRequest(APIConstant.GetPhotosEndPoint)
                .AddHeader("Content-Type", ContentType.Json)
                .AddHeader("Accept", ContentType.Json)
                .AddHeader("Authorization", "Bearer " + tokenId)
                .ExecuteGetAsync<List<GetAllPhotosDto>>();
             return res;
        }
        public async Task<RestResponse> likePhoto(PhotoRequestDto photo, string tokenId)
        {
            var res = await _client.CreateRequest(APIConstant.GetLikePhotoEndPoint(photo.id.ToString()))
                .AddHeader("Content-Type", ContentType.Json)
                .AddHeader("Accept", ContentType.Json)
                .AddHeader("Authorization", "Bearer " + tokenId)
                .AddBody(photo)
                .ExecutePostAsync();
            return res;
        }
        public async Task likePhotos(List<string> photoIds, string tokenId)
        {
            foreach (var photoId in photoIds)
            {
                await likePhoto(new PhotoRequestDto() { id = photoId }, tokenId);
            }
        }
        public async Task<RestResponse> UnlikePhoto(PhotoRequestDto photo, string tokenId)
        {
            var res = await _client.CreateRequest(APIConstant.GetLikePhotoEndPoint(photo.id.ToString()))
                .AddHeader("Content-Type", ContentType.Json)
                .AddHeader("Accept", ContentType.Json)
                .AddHeader("Authorization", "Bearer " + tokenId)
                .AddBody(photo)
                .ExecuteDeleteAsync();
            return res;
        }

      }
}