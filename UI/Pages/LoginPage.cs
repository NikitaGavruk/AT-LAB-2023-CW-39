using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Pages
{
    internal class LoginPage :AbstractPage
    {
        private static readonly By usernameField = By.CssSelector("#wpName1");
        private static readonly By passwordField = By.CssSelector("#wpPassword1");
        private static readonly By rememberMeCheckbox = By.CssSelector("#wpRemember");
        private static readonly By loginButton = By.CssSelector("#wpLoginAttempt");
    }
}
