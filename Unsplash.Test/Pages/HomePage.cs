using CSharpAutomationFramework.Core.Drivers;
using CSharpAutomationFramework.Core.Element;
using CSharpAutomationFramework.Core.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Unsplash.Test.Services.Models;

namespace Unsplash.Test.Pages
{
    public class HomePage
    {
        private Element loginLink = new Element(By.XPath("//a[contains(.,'Log in')]"));
        private Element loginedMenu = new Element(By.Id("popover-avatar-loggedin-menu"));
        private Element viewProfileSubMenu = new Element(By.XPath("//a[contains(.,'View profile')]"));
        private Element likeButton = new Element(By.XPath("//button[@title='Like']"));
        private Element photos = new Element(By.XPath("//div[@data-test='masonry-grid-count-three']/descendant::img[@data-test='photo-grid-masonry-img']"));
        public LoginPage GotoLoginPage()
        {
            LoginPage loginPage = new LoginPage();
            HomePage homePage = new HomePage();
            homePage.loginLink.Click();
            return loginPage;
        }
        public HomePage Login(string username, string password)
        {
            LoginPage loginPage = GotoLoginPage();
            loginPage.Login(username, password);
            return new HomePage();
        }
        public ProfilePage GotoProfilePage()
        {
            loginedMenu.Click();
            viewProfileSubMenu.Click();
            return new ProfilePage();
        }
        public bool IsLoggedIn()
        {
            return loginedMenu.IsExisted();
        }
        public IList<IWebElement> GetAllPhotos()
        {
            return photos.GetListElements();
        }
        public IList<IWebElement> GetAllLikeButtons()
        {
            return likeButton.GetListElements();
        }
        public IWebElement? GetFirstPhoto()
        {
            return GetAllPhotos().FirstOrDefault();
        }

        public void MoveOver()
        {
            GetAllPhotos().FirstOrDefault()?.MoveOver();
        }

        public void LikePhoto(IWebElement e)
        {
            e.Click();
        }
        public void likeRandomPhotos(int numOfPhotos)
        {
            var photos = GetAllPhotos();
            var likes = GetAllLikeButtons();
            Random rnd = new Random();
            for ( int i =0 ; i < numOfPhotos; i++)
            {
                int randIndex = rnd.Next(photos.Count - 1);
                photos[randIndex].MoveOver();
                LikePhoto(likes[randIndex]);
            }

        }
        public List<PhotoResponseDto> AddRandomPhotosToCollection(int numberOfPhotos, string collectionTitle)
        {
            List<PhotoResponseDto> photos = new List<PhotoResponseDto>();
            for (int i = 1; i <= numberOfPhotos; i++)
            {
                PhotoSectionPage photoSectionPage = new PhotoSectionPage();
                PhotoDetailPage photoDetailPage = new PhotoDetailPage();
                photos.Add(new PhotoResponseDto
                {
                    id = photoSectionPage.GetPhotoId(i),
                    description = photoSectionPage.GetPhotoTitle(i)
                });

                photoSectionPage.ViewPhotoTitleByIndex(i);
                photoDetailPage.AddPotoToCollection(collectionTitle);
                // not work new Element(By.XPath("//body")).Click(); -> hard code here for testing
                DriverManager.GetCurrentDriver().GoToUrl("https://unsplash.com");
            }
            return photos;
        }
        public void RemovePhotoFromCollection(string photoTitle, string collectionTitle)
        {
            GotoProfilePage();
            ProfilePage profilePage = new ProfilePage();
            profilePage.ViewCollectionDetail(collectionTitle);

            PhotoSectionPage photoSectionPage = new PhotoSectionPage();
            PhotoDetailPage photoDetailPage = new PhotoDetailPage();
            photoSectionPage.ViewPhotoTitleByTitle(photoTitle);
            photoDetailPage.RemovePhotoOutOfCollection(collectionTitle);

        }

    }
}
