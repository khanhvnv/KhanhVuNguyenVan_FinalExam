using CSharpAutomationFramework.Core.Drivers;
using CSharpAutomationFramework.Core.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Drawing;


namespace CSharpAutomationFramework.Core.Element
{
    public class Element
    {
        protected By locator;
        protected float timeout = 30;
        public Element(By locator)
        {
            this.locator = locator;
        }
        public Element(By locator, float timeOutInSecond)
        {
            this.locator = locator;
            timeout = timeOutInSecond;
        }
        public Element SetTimeOut(float timeOutInSecond)
        {
            this.timeout = timeOutInSecond;
            return this;
        }
        public By GetLocator()
        {
            return this.locator;
        }
        public IWebElement WaitForVisiblility()
        {
            return DriverManager.GetCurrentDriver().WaitForElementToBeVisible(this.locator, this.timeout);
        }
        public IList<IWebElement> GetListElements()
        {
            return DriverManager.GetCurrentDriver().FindElements(this.locator);
        }
        //Why String? string is ok?
        public String GetAttribute(string name)
        {
            return WaitForVisiblility().GetAttribute(name);
        }
        public String GetDomAttribute(string name)
        {
            return WaitForVisiblility().GetDomAttribute(name);
        }
        public String GetText()
        {
            return WaitForVisiblility().Text;
        }
        public bool IsDisplayed()
        {
            return WaitForVisiblility().Displayed;
        }
        public bool IsSelected()
        {
            return WaitForVisiblility().Selected;
        }
        public bool IsEnabled()
        {
            return WaitForVisiblility().Enabled;
        }
        public bool IsExisted()
        {
            try
            {
                WaitForVisiblility();
                return true;
            }
            catch (Exception){ return false; }
        }

        public bool WaitForInVisibility()
        {
            return DriverManager.GetCurrentDriver().WaitForInVisiblility(this.locator, this.timeout);
        }
        public bool IsInVisible()
        {
            return WaitForInVisibility();
        }
        public void Submit()
        {
            (WaitForVisiblility() as WebElement).Submit();
        }
        public void Enter(string text, bool isClicEnterKey = false, bool isClearByKeyBoard = false)
        {
            DriverManager.GetCurrentDriver().EnterText(this.locator, text, isClicEnterKey, isClearByKeyBoard);
        }
        public void SendKeys(string text)
        {
            WaitForVisiblility().SendKeys(text);
        }
        public void Clear(bool isClearByKeyBoard)
        {
            DriverManager.GetCurrentDriver().ClearTextBox(this.locator, isClearByKeyBoard);
        }
        public void Click()
        {
            DriverManager.GetCurrentDriver().Click(this.locator, this.timeout);
        }
        public void ClickByJs()
        {
            DriverManager.GetCurrentDriver().ClickByJS(this.locator);
        }
         public Point GetLocation()
        {
            return WaitForVisiblility().Location;
        }
        public void ScrollAndClick()
        {
            Point location = GetLocation();
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverManager.GetCurrentDriver();
            js.ExecuteScript($"window.scrollBy({location.X},{location.Y})");
            Click();
        }
        public ReadOnlyCollection<IWebElement> FindElements()
        {
            WaitForVisiblility();
            return DriverManager.GetCurrentDriver().FindElements(this.locator);
        }
        public ReadOnlyCollection<IWebElement> FindSubElements(By child)
        {
            WaitForVisiblility();
            return DriverManager.GetCurrentDriver().FindElement(this.locator).FindElements(this.locator);
        }
        public void PressEscKey()
        {
            Actions action = new Actions(DriverManager.GetCurrentDriver());
            action.SendKeys(Keys.Escape);
        }

    }
}
