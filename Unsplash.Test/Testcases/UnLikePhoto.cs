using CSharpAutomationFramework.Core.Reports;
using Unsplash.Test.Pages;
using Unsplash.Test.Services.Data;
using Unsplash.Test.Services.Models;

namespace Unsplash.Test.Testcases
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("unlikephotos")]
    public class UnLikePhoto: BaseTest
    {
        public async Task<List<string>> SetupToLikePhotos(int numberOfUnlikePhotos)
        {
            List<string> photoIds = new List<string>();
            //Like some photos
            var allPhotos = await _photoServices.GetAllPhotos(_defaultUser.tokenId);
            if(allPhotos.Data!=null){
                foreach (var photo in allPhotos.Data.Take(numberOfUnlikePhotos))
                {
                    photoIds.Add(photo.id);
                }
                await _photoServices.likePhotos(photoIds,_defaultUser.tokenId);
                //Store liked photos to DataStorage
                DataStorage.AddLikePhotos(testcaseId,photoIds);
            }
            return photoIds;
        }
        [TearDown]
        public async Task AfterTestCase()
        {
            var likedPhotos = DataStorage.GetLikePhoto(testcaseId);
            //UnLike liked photos in tcs
            foreach(var photoId in likedPhotos)
            {
                await _photoServices.UnlikePhoto(new PhotoRequestDto() {id= photoId}, _defaultUser.tokenId);
            }
        }
        [Test, Category("unlikephotos")]
        [TestCase(5)]
        public async Task UnlikeListLikedPhotoSuccessfully(int numberOfUnlikePhotos)
        {
            //Setup: Prepare data (like 5 photos)
            var photoIds = await SetupToLikePhotos(numberOfUnlikePhotos);
            /*
             * Scenario 1: UnLike 5 photos in the list liked photos
                *	Given I log in with account "<account_name>"
                *	And go to profile page and click Likes Photo tab
                *	When I perform unlike 5 photos
                *	Then verify 5 photos are unliked successfully
             * */
            ReportLog.Info("1.Given I log in with account " + _defaultUser.username);
            homePage = homePage.Login(_defaultUser.email, _defaultUser.password);

            ReportLog.Info("2. And go to profile page and click Likes Photo tab");
            ProfilePage profilePage = homePage.GotoProfilePage();
            LikePage likePage= profilePage.goToLikePage();

            ReportLog.Info("3. When I perform unlike 5 photos");
            likePage.UnLikePhotoByPhotoIds(photoIds);

            ReportLog.Info("4. Then verify 5 photos are unliked successfully");
            Assert.That(likePage.NotExistPhotosByPhotoIds(photoIds),"One of photos unliked unsuccessfully");         
        }
    }
}
