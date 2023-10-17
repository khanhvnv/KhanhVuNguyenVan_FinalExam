using CSharpAutomationFramework.Core.Drivers;
using CSharpAutomationFramework.Core.Element;
using OpenQA.Selenium;


namespace Unsplash.Test.Pages
{
    public class PhotoDetailPage
    {
        private Element closeButton = new Element(By.XPath("//*[local-name()='desc' and .='An X shape']/.."));

        private Element BTN_LIKE => new Element(By.XPath(
            $"//div[contains(@data-test,\"photos-route\")]//button[@title=\"Like\"]"));
        private Element BTN_ADD_TO_COLLECTION => new Element(By.XPath(
            $"//div[contains(@data-test,\"photos-route\")]//button[@title=\"Add to collection\"]"));
        private Element BTN_DOWNLOAD => new Element(By.XPath(
            $"//a[@title='Download photo' and .='Download']"));
        private Element BTN_REMOVE_PHOTO_FROM_COLLECTION_XPATH(string collectionTitle) => new Element(By.XPath(
            $"//button//span[text()=\"{collectionTitle}\"]"));
        private Element BTN_ADD_PHOTO_TO_COLLECTION_XPATH(string collectionTitle) => new Element(By.XPath(
            $"//button//span[text()=\"{collectionTitle}\"]"));

        public void ClickAddCollectionButton()
        {
            BTN_ADD_TO_COLLECTION.Click();
        }
        public void ClickLikeButton()
        {
            BTN_LIKE.Click();
        }
        public void ClickUnLikeButton()
        {
            BTN_LIKE.Click();
        }

        public void ClickDownloadButton()
        {
            BTN_DOWNLOAD.Click();
        }

        public void ClickRemoveCurrentPhotoFromCollection(string collectionTitle)
        {
            BTN_REMOVE_PHOTO_FROM_COLLECTION_XPATH(collectionTitle).Click();
        }
        public void RemovePhotoOutOfCollection(string collectionTitle)
        {
            ClickAddCollectionButton();
            ClickRemoveCurrentPhotoFromCollection(collectionTitle);
        }
        public void AddPotoToCollection(string collectionTitle)
        {
            BTN_ADD_TO_COLLECTION.Click();
            //check if item has not clicked yet (check number of photo text)
            BTN_ADD_PHOTO_TO_COLLECTION_XPATH(collectionTitle).Click();
        }
        public string GetPhotoIdFromUrl()
        {
            return DriverManager.GetCurrentDriver().Url.Split('/').Last();
        }
        public void ClickCloseButton()
        {
            closeButton.Click(); 
        }
    }
}
