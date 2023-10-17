using CSharpAutomationFramework.Core.Reports;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Unsplash.Test.Pages;
using Unsplash.Test.Services.Data;
using Unsplash.Test.Services.Models;

namespace Unsplash.Test.Testcases
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("collection")]
    public class Collection : BaseTest
    {
      
        /* Scenario 2: Delete a collection successfully
            * Given I log in with account <"account_name">
            * And I go to profile page and click to Collection tab
            * When I choose a collection
            * And I click edit button on collection page
            * And I click Delete Collection hyperlink
            * Then Verify this collection is deleted
        */

        [SetUp]
        public async Task BeforeTestCase()
        {
            //create a collection and store to DataStorage
            CollectionRequestDto privateCollection = new CollectionRequestDto()
            {
                title = "ID_" + testcaseId + "_" + DateTime.Now.Ticks.ToString(),
                description = "new test collection",
                @private = true
            };
            var createdCollection = await _collectionServices.CreateCollection(privateCollection, _defaultUser.tokenId);
            if(createdCollection.Data!=null)
                DataStorage.StoreCollection(testcaseId, createdCollection.Data);
        }
        [TearDown]
        public async Task AfterTestCase()
        {
            //delete collection created during running testcase
            List<CollectionResponseDto> collections = DataStorage.GetCollections(testcaseId);
            collections.ForEach(async x => {
                await _collectionServices.DeleteCollection(x.id, _defaultUser.tokenId);
            });
        }

       
        [Test, Category("remove collection")]
        [TestCase]
        public async Task DeleteACollectionSuccessfully()
        {
            //declare collectionTitle variable from DataStorage 
            var collectionTitle = DataStorage.GetFirstCollection(testcaseId).title;

            ReportLog.Info("1.Given I log in with account " + _defaultUser.username);
            homePage = homePage.Login(_defaultUser.email, _defaultUser.password);

            ReportLog.Info("2. And I go to profile page and click to Collection tab");
            ProfilePage profilePage = homePage.GotoProfilePage();
            profilePage.ClickCollectionsTab();

            ReportLog.Info("3. When I choose a collection");
            CollectionPage collectionPage = profilePage.ViewCollectionDetail(collectionTitle);

            ReportLog.Info("4. And I click edit button on collection page");
            EditCollectionPage editCollectionPage = collectionPage.ClickEditCollectionButton();

            ReportLog.Info("5. And I click Delete Collection hyperlink and confirm");
            editCollectionPage.ClickDeleteCollectionHyperlink();
            collectionPage = editCollectionPage.ClickConfirmDeleteCollectionButton();

            ReportLog.Info("6. Then Verify this collection is deleted");
            collectionPage.NotExistCollectionByCollectionTitle(collectionTitle).Should().Be(true);
        }
    }
}
