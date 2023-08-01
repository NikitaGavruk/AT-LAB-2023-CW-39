using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class LoginPage :AbstractPage
    {
        private static readonly By usernameField = By.CssSelector("#wpName1");
        private static readonly By passwordField = By.CssSelector("#wpPassword1");
        private static readonly By rememberMeCheckbox = By.CssSelector("#wpRemember");
        private static readonly By loginButton = By.CssSelector("#wpLoginAttempt");       

        public void EnterUsername(string username, int timeSeconds)
        {
            WebDriverExtension.SendKeysToElement(usernameField, username, timeSeconds);
        }

        public void EnterPassword(string password, int timeSeconds)
        {
            WebDriverExtension.SendKeysToElement(passwordField, password, timeSeconds);
        }

        public MainPage ClickToLoginButton(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(loginButton, timeSeconds);
            return new MainPage();
        }
    }
}