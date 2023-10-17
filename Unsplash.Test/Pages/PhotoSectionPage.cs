using CSharpAutomationFramework.Core.Element;
using OpenQA.Selenium;


namespace Unsplash.Test.Pages
{
    public class PhotoSectionPage
    {
        private Element photoImageByIndex(string index) => new Element(By.XPath(
            $"//div[contains(@data-test,\"masonry-grid-count-three\")]/div[{index}]//a"));

        private Element photoImageByTitle(string title) => new Element(By.XPath(
            $"//div[contains(@data-test,\"masonry-grid-count-three\")]//a[contains(@title,\"{title}\")]"));

        private Element photoLinkById (string photoId) => new Element(By.XPath(
            $"//a[contains(@itemprop,'contentUrl') and contains(@href,'{photoId}')]/div"));

        public string GetPhotoTitle(int index)
        {
            return photoImageByIndex(index.ToString()).GetDomAttribute("title");
        }
        public string GetPhotoId(int index)
        {
            return photoImageByIndex(index.ToString()).GetDomAttribute("href").Replace("/photos/", "");
        }
        public PhotoDetailPage ViewPhotoTitleByIndex(int index)
        {
            photoImageByIndex(index.ToString()).Click();
            return new PhotoDetailPage();
        }
        public void ViewPhotoTitleByTitle(string title)
        {
            photoImageByTitle(title).Click();
        }
        public PhotoDetailPage ViewPhotoByPhotoId(string photoId)
        {
            photoLinkById(photoId).ScrollAndClick();
            return new PhotoDetailPage();
        }
        public bool WaitPhotoForInVisibility(string photoId)
        {
           return photoLinkById(photoId).WaitForInVisibility();
        }
        public bool WaitPhotoForInVisibility(List<string> photoIds)
        {
            foreach(string photoId in photoIds)
            {
                if(!photoLinkById(photoId).WaitForInVisibility()) return false;
            }
            return true;
        }
    }
}
