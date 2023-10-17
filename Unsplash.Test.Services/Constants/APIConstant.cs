
namespace Unsplash.Test.Services.Constants
{
    public class APIConstant
    {
        public static string GetCreateCollectionEndPoint = "/collections/";
        public static string DeleteCollectionEndPoint(string collectionId) => $"/collections/{collectionId}";
        public static string DeletePhotoCollectionEndPoint(string collectionId) =>  $"collections/${collectionId}/remove";
        public static string GetPhotosEndPoint= "/photos/";
        public static string GetAPhotoEndPoint(string photoId)=> $"/photos/{photoId}";
        public static string GetLikePhotoEndPoint(string photoId)=> $"/photos/{photoId}/like";
        public static string GetLikesOfUserEndPoint(string username)=> $"/users/{username}/likes";

        
    }
}
