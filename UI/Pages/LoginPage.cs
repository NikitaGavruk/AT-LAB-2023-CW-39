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
        public static readonly By usernameField = By.CssSelector("#wpName1");
        public static readonly By passwordField = By.CssSelector("#wpPassword1");
        public static readonly By rememberMeCheckbox = By.CssSelector("#wpRemember");
        public static readonly By loginButton = By.CssSelector("#wpLoginAttempt");
    }
}
