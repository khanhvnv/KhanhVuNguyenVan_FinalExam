using AventStack.ExtentReports.Gherkin.Model;
using CSharpAutomationFramework.Core.Element;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Pages
{
    public class ProfilePage:HomePage
    {
        private Element editProfileButton = new Element(By.XPath("//a[contains(.,'Edit profile')]"));
        private Element collectionsTab= new Element(By.XPath("//a[@data-test='user-nav-link-collections']"));
        private Element fullUserNameText= new Element(By.XPath("//a[contains(.,'Edit profile')]/../preceding-sibling::div"));
        private Element updateAccountButton = new Element(By.XPath("//input[contains(@value,'Update account')]"));
        private Element username = new Element(By.Id("user_username"));
        private Element menuButton = new Element(By.XPath("//button[@title='Your personal menu button']"));
        private Element profileMenu = new Element( By.XPath("//a[text()='View profile']"));
        private Element likeMenu = new Element(By.XPath("//a[@data-test='user-nav-link-likes']"));
        private Element likedPhotos = new Element(By.XPath("//img[@data-test='photo-grid-masonry-img']"));
        private Element collectionItem(string collectionTitle) => new Element(By.XPath($"//div[.='{collectionTitle}']"));
 

        public void CLickEditTagLink()
        {
            editProfileButton.Click();
        }
        public void EditUsername(string newUsername)
        {
            username.Enter(newUsername);
        }
        public void CLickUpdateAccountButton()
        {
            updateAccountButton.Click();
        }

        public bool IsProfilePage()
        {
            return editProfileButton.IsExisted();
        }
        public string getFullUserName()
        {
            return fullUserNameText.GetText();
        }
        public void ClickCollectionsTab()
        {
            collectionsTab.Click();
        }
        public CollectionPage ViewCollectionDetail(string collectionTitle)
        {
            ClickCollectionsTab();
            collectionItem(collectionTitle).Click();
            return new CollectionPage();
        }
     

        public void goToProfile()
        {
            menuButton.Click();
            profileMenu.Click();
        }
        public LikePage goToLikePage()
        {
            likeMenu.Click();
            return new LikePage();
        }
        public IList<IWebElement> GetLikedPhotosList()
        {
            return likedPhotos.GetListElements();
        }


    }
}
