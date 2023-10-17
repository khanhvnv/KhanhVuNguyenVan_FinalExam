using CSharpAutomationFramework.Core.Drivers;

namespace Unsplash.Test.Pages
{
    public class LikePage
    {        
        public PhotoDetailPage UnLikePhotoByPhotoId(string photoId)
        {
            PhotoSectionPage photoSectionPage = new PhotoSectionPage();
            PhotoDetailPage photoDetailPage= photoSectionPage.ViewPhotoByPhotoId(photoId);
            photoDetailPage.ClickUnLikeButton();  
            return photoDetailPage;
        }
        public void UnLikePhotoByPhotoIds(List<string> photoIds)
        {
            foreach (string photoId in photoIds)
            {
                var photoDetailPage = UnLikePhotoByPhotoId(photoId);
                //close photo detail page
                photoDetailPage.ClickCloseButton();
            }
        }
        public bool NotExistPhotosByPhotoIds(List<string> photoIds)
        {
            //refresh page to get updates
            DriverManager.GetCurrentDriver().Navigate().Refresh();
            return new PhotoSectionPage().WaitPhotoForInVisibility(photoIds);
        }

    }
}
