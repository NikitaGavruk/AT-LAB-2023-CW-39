using OpenQA.Selenium;
using UI.Utils;
using UI.WebDriver;

namespace UI.Pages
{
    public class LoginPage : AbstractPage
    {
        private static readonly By usernameField = By.CssSelector("#wpName1");
        private static readonly By passwordField = By.CssSelector("#wpPassword1");
        private static readonly By rememberMeCheckbox = By.CssSelector("#wpRemember");
        private static readonly By loginButton = By.CssSelector("#wpLoginAttempt");

        public LoginPage EnterUsername(string username)
        {
            WebDriverExtension.SendKeysToElement(usernameField, username);
            return new LoginPage();

        }

        public LoginPage EnterPassword(string password)
        {
            WebDriverExtension.SendKeysToElement(passwordField, password);
            return new LoginPage();
        }

        public MainPage ClickToLoginButton()
        {
            WebDriverExtension.ClickOnElement(loginButton);
            return new MainPage();
        }
    }
}