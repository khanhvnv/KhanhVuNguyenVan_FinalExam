using CSharpAutomationFramework.Core.Element;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Pages
{
    public class EditCollectionPage
    {
        private Element deleteCollectionHyperlink = new Element(By.XPath("//button[.='Delete Collection']"));
        private Element confirmDeleteCollectionButton = new Element(By.XPath("//button[.='Delete']"));

        public void ClickDeleteCollectionHyperlink()
        {
            deleteCollectionHyperlink.Click();
        }
        public CollectionPage ClickConfirmDeleteCollectionButton()
        {
            confirmDeleteCollectionButton.Click();
            return new CollectionPage();
        }
    }
}
