using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Pages
{
    internal class LoginPage :AbstractPage
    {
        public static readonly By usernameField = By.CssSelector("#wpName1");
        public static readonly By passwordField = By.CssSelector("#wpPassword1");
        public static readonly By rememberMeCheckbox = By.CssSelector("#wpRemember");
        public static readonly By loginButton = By.CssSelector("#wpLoginAttempt");

        public void Login(string username, string password)
        {
            WebDriverExtension.SendKeysToElement(usernameField, username, 5);
            WebDriverExtension.SendKeysToElement(passwordField, password, 1);
            WebDriverExtension.ClickOnElement(loginButton, 1);
        }
    }
}
