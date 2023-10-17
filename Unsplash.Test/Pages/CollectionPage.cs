using CSharpAutomationFramework.Core.Element;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Pages
{
    public class CollectionPage
    {
        private Element photoInCollection(string title) => new Element(By.XPath($"//a[contains(@title,'{title}')]"));
        private Element numberOfPhotos = new Element(By.XPath("//span[contains(.,'photo')]"));
        private Element editCollectionButton= new Element(By.XPath("//button[.='Edit']"));
        private Element collectionNameLabel(string title) => new Element(By.XPath($"//a[contains(@href,'{title}')]"));


        public EditCollectionPage ClickEditCollectionButton()
        {
            editCollectionButton.Click();
            return new EditCollectionPage();
        }
        public string GetNumberOfPhotos(string collectionId)
        {
            return numberOfPhotos.GetText().Replace(" photo", "");
        }

        public bool WaitPhotoForInVisiblility(string title)
        {
            return photoInCollection(title).WaitForInVisibility();
        }

        public bool NotExistCollectionByCollectionTitle(string title)
        {
            return collectionNameLabel(title).WaitForInVisibility();
        }
    }
}
