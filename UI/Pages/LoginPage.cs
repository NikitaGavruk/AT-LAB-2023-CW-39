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

        public void EnterUsername(string username, int timeSeconds)
        {
            WebDriverExtension.SendKeysToElement(usernameField, username, timeSeconds);
        }

        public void EnterPassword(string password, int timeSeconds)
        {
            WebDriverExtension.SendKeysToElement(passwordField, password, timeSeconds);
        }

        public void ClickToLoginButton(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(loginButton, timeSeconds);
        }
    }
}
