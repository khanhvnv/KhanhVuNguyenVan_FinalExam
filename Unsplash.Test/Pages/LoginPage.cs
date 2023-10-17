using OpenQA.Selenium;
using CSharpAutomationFramework.Core.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Pages
{
    public class LoginPage : HomePage
    {
        private Element usernameTextBox = new Element(By.Id("user_email"));
        private Element passwordTextBox = new Element(By.Id("user_password"));
        private Element loginButton = new Element(By.Name("commit"));
        
        public HomePage Login(string username, string password)
        {
            usernameTextBox.Enter(username);
            passwordTextBox.Enter(password);
            loginButton.WaitForVisiblility().Click();
            return new HomePage();
        }
    }
}
