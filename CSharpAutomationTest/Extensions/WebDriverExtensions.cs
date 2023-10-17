using OpenQA.Selenium;
using CSharpAutomationFramework.Core.Drivers;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using CSharpAutomationFramework.Core.Configs;

namespace CSharpAutomationFramework.Core.Extensions
{
    public static class WebDriverExtensions
    {
        public static void Quit(this IWebDriver driver) => driver.Quit();
        public static void MaximizeWindow(this IWebDriver driver) => driver.Manage().Window.Maximize();
        public static void GoToUrl(this IWebDriver driver, string url)
        {
            driver.MaximizeWindow();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Navigate().GoToUrl(url);
        }
        public static void Visit(this IWebDriver driver, string location = "")
        {
            driver.GoToUrl(Application.GetConfig()["baseurl"]+location);
        }
        public static void RefreshPage(this IWebDriver driver) => driver.Navigate().Refresh();
        public static void ClickBackButton(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.history.back()");
        }
        public static void DeleteAllCookie(this IWebDriver driver) => driver.Manage().Cookies.DeleteAllCookies();
        public static void GetCookie(this IWebDriver driver, string cookieName) => driver.Manage().Cookies.GetCookieNamed(cookieName);
        public static string GetTokenLocalStorage(this IWebDriver webDriver)
        {
            return webDriver.GetTokenLocalStorage();
        }
        public static void ClearTokenLocalStorage(this IWebDriver webDriver)
        {
            IJavaScriptExecutor java = (IJavaScriptExecutor)webDriver;
            java.ExecuteScript($"return window.localStorage.Clear();");
        }
        public static void SwitchToFirstTab(this IWebDriver driver) => driver.SwitchTo().Window(driver.WindowHandles.First());
        public static void SwitchToLastTab(this IWebDriver driver) => driver.SwitchTo().Window(driver.WindowHandles.Last());
        public static void SwitchToTab(this IWebDriver driver, int positionTab, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(x => (driver.WindowHandles.Count() >= positionTab));
            driver.SwitchTo().Window(driver.WindowHandles[positionTab - 1]);
            driver.WaitForPageReady();
        }
        public static void SwitchToFirstTabAndCloseAllOtherTabs(this IWebDriver driver)
        {
            int tabNumbers = driver.WindowHandles.Count();
            while (tabNumbers > 1)
            {
                driver.SwitchToTab(tabNumbers);
                driver.Close();
                tabNumbers--;
            }
            driver.SwitchToFirstTab();
        }
        public static void WaitForPageReady(this IWebDriver driver, float timeout = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(w => ((IJavaScriptExecutor)w).ExecuteScript("return documeent.readyState").ToString().Equals("complete"));
        }
        public static bool WaitForInVisiblility(this IWebDriver driver, By locator, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        public static bool IsElementToBeVisible(this IWebDriver driver, By locator, float timeout = 30)
        {
            try
            {
                WaitForElementToBeVisible(driver, locator, timeout);
                return true;
            }
            catch (WebDriverException) { return false; }
        }
        public static bool IsSubElementToBeVisible(this IWebElement element, By locator, float timeout = 30)
        {
            bool isDisplayed = false;
            while (true)
            {
                try
                {
                    timeout -= 1;
                    if (timeout < 0) return false;
                    isDisplayed = element.FindElement(locator).Displayed;
                    if (isDisplayed) return true;
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                }
            }
        }
        public static IWebElement WaitForElementToBeVisible(this IWebDriver driver, By locator, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public static IWebElement WaitForElementToBeClickable(this IWebDriver driver, By locator, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public static IWebElement WaitForElementToBeExist(this IWebDriver driver, By locator, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }
        public static ReadOnlyCollection<IWebElement> WaitVisibilityOfAllElementsLocatedBy(this IWebDriver driver, By locator, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }
        public static void WaitForUrl(this IWebDriver driver, string url, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(x => x.Url.Contains(url));
        }
        public static void WaitForElementEnable(IWebDriver driver, By locator, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(x => (driver.FindElement(locator).GetAttribute("disabled") != "true"));
        }
        public static bool WaitTextToBePresentInElementLocated(this IWebDriver driver, By locator, string text, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }
        public static bool WaitTextToBePresentInElementValued(this IWebDriver driver, By locator, string text, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.TextToBePresentInElementValue(locator, text));
        }
        public static bool WaitForElementTextDisplay(this IWebDriver driver, By locator, string text, float timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(x => (driver.FindElement(locator).Text.Trim() == text));
        }

        //Handle actions
        public static void RemoveElementByJS(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("argument[0].remove();", element);
        }
        public static void Click(this IWebDriver driver, By locator, float timeout = 30)
        {
            Actions action = new Actions(driver);
            IWebElement element = driver.WaitForElementToBeClickable(locator, timeout);
            action.MoveToElement(element).Click().Build().Perform();
        }
        public static void ClickByJS(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.WaitForElementToBeClickable(locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("argument[0].scrollIntoView(true);", element);
            js.ExecuteScript("argument[0].click();", element);
            js.ExecuteScript("argument[0].style;", element);
        }
        public static void ClickAndSelect(this IWebDriver driver, By byLocatorDropDownList, string optionText, string optionTagName = "option", float timeout = 30)
        {
            driver.Click(byLocatorDropDownList, timeout);
            driver.Select(byLocatorDropDownList, optionTagName, optionTagName, timeout);
        }
        public static void Select(this IWebDriver driver, By byLocatorSelect, string optionText, string optionTagName = "option", float timeout = 30)
        {
            driver.WaitForElementToBeVisible(byLocatorSelect, timeout: timeout);
            IWebElement element = driver.FindElement(byLocatorSelect);
            element.Select(optionText, optionTagName, timeout);
        }
        public static void Select(this IWebElement element, string optionText, string optionTagName = "option", float timeout = 30)
        {
            foreach (var item in element.FindElements(By.TagName(optionTagName)))
            {
                if (item.GetAttribute("outerText").Trim().Contains(optionText))
                {
                    item.Click();
                    return;
                }
            }
            throw new Exception($"Not find option {optionText}");
        }
        public static void Select(this ReadOnlyCollection<IWebElement> elements, string optionText, float timeout = 30)
        {
            foreach (var item in elements)
            {
                if (item.GetAttribute("outerText").Trim().Contains(optionText))
                {
                    item.Click();
                    return;
                }
            }
            throw new Exception($"Not find option {optionText}");
        }
        public static void DoubleClick(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.WaitForElementToBeClickable(locator);
            driver.DoubleClick(locator);
        }
        public static void DoubleClickElement(this IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).DoubleClick().Build().Perform();
        }

        public static void Hover(this IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
        }
        public static void MoveToElement(this IWebDriver driver, By locator)
        {
            Actions action = new Actions(driver);
            IWebElement element = driver.WaitForElementToBeClickable(locator);
            action.MoveToElement(element).Build().Perform();
        }
        public static void MoveToElementByJS(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.WaitForElementToBeClickable(locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("argument[0].scrollIntoView(true);", element);
        }
        public static void EnterText(this IWebDriver driver, By locator, string text, bool isClicEnterKey = false, bool isClearByKeyBoard = false)
        {
            IWebElement element = driver.WaitForElementToBeClickable(locator);
            element.ClearTextBoxElement(isClearByKeyBoard);
            element.SendKeys(text ?? "");
            if (isClicEnterKey)
                element.SendKeys(Keys.Enter);
        }
        public static void ClearTextBox(this IWebDriver driver, By locator, bool isClearByKeyBoard = false)
        {
            IWebElement element = driver.WaitForElementToBeVisible(locator);
            element.ClearTextBoxElement(isClearByKeyBoard);
        }
        public static void ClearTextBoxElement(this IWebElement element, bool isClearByKeyBoard = false)
        {
            element.Click();
            if (isClearByKeyBoard)
            {
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
            }
            else
                element.Clear();
        }
        public static void ScrollToViewElement(this IWebDriver webDriver, By locator)
        {
            IWebElement element = webDriver.FindElement(locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("argument[0].scrollIntoView(true);", element);
        }
        //handle get Data
        public static string GetText(this IWebDriver webDriver, By locator)
        {
            return WaitForElementToBeVisible(webDriver, locator).Text;
        }
        public static string GetValue(this IWebDriver webDriver, By locator)
        {
            return WaitForElementToBeVisible(webDriver, locator).GetAttribute("value");
        }
        public static string GetTextByJS(this IWebDriver driver, By locator)
        {
            object text = ((IJavaScriptExecutor)driver).ExecuteScript("", driver.FindElement(locator));
            return (string)text;
        }
        public static List<string> GetTextFromElement(this IWebDriver webDriver, By locator)
        {
            ReadOnlyCollection<IWebElement> listElements = null;
            listElements = WaitVisibilityOfAllElementsLocatedBy(webDriver, locator);
            return listElements.GetTextFromElement();
        }
        public static List<string> GetTextFromElement(this ReadOnlyCollection<IWebElement> elements)
        {
            return elements.Select(e => e.Text.Trim()).ToList();
        }
        public static string GetTextCurrentSelectOption(this IWebDriver driver, By locator, string optionTagName = "option")
        {
            var dropdownList = driver.FindElement(locator);
            return dropdownList.GetTextCurrentSelectOption(optionTagName);
        }
        public static string GetTextCurrentSelectOption(this IWebElement dropdownList, string optionTagName = "option")
        {
            var options = dropdownList.FindElements(By.TagName(optionTagName));
            var value = dropdownList.GetAttribute("value");
            foreach (var option in options)
            {
                if (option.GetAttribute("value") == value)
                    return option.GetAttribute("outerText").Trim();
            }
            return null;
        }
        public static string GetAttribute(this IWebDriver driver, By locator, string attributeName)
        {
            return WaitForElementToBeExist(driver,locator).GetAttribute(attributeName);
        }
        public static bool IsElementEnable(this IWebDriver driver, By locator)
        {
            return WaitForElementToBeExist(driver, locator).Enabled;
        }
        public static void MoveOver(this IWebElement elememt)
        {
            var mouseAction = new Actions(DriverManager.GetCurrentDriver());
            mouseAction.MoveToElement(elememt).Perform();
        }
    }
}