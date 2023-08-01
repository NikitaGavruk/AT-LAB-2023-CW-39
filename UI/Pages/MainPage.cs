using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class MainPage : AbstractPage
    {
        private static readonly By searchField = By.CssSelector("[name='search']");
        private static readonly By searchButton = By.CssSelector(".cdx-button.cdx-search-input__end-button");
        private static readonly By loginButton = By.CssSelector("#pt-login-2>a>span");
        private static readonly By openSideMenuButton = By.CssSelector("#vector-main-menu-dropdown-label");
        private static readonly By randomPageButton = By.CssSelector("#n-randompage>a>span");
        private static readonly By title = By.CssSelector("#Welcome_to_Wikipedia");
        private static readonly By userDropdownMenu = By.CssSelector("#vector-user-links-dropdown-checkbox");
        private static readonly By logoutButton = By.XPath("//*[@id='pt-logout']/a/span[2]");
        private static readonly By loggedUsername = By.CssSelector("#pt-userpage-2>a>span");

        public bool IsPageVisible(int timeSeconds)
        {
            return WebDriverExtension.IsElementVisible(title, timeSeconds);
        }

        public LoginPage ToLoginPage(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(loginButton, timeSeconds);
            return new LoginPage();
        }

        public void CallUserDropdownMenu(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(userDropdownMenu, timeSeconds);
        }

        public LogoutPage ClickToLogout(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(logoutButton, timeSeconds);
            return new LogoutPage();
        }

        public void SendKeysToSearchField(string searchText, int timeSeconds)
        {
            WebDriverExtension.SendKeysToElement(searchField, searchText, timeSeconds);
        }

        public ArticlePage ClickToSearchButton(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(searchButton, timeSeconds);
            return new ArticlePage();
        }

        public string GetLoggedUsername(int timeSeconds)
        {
            return WebDriverExtension.GetTextFromElement(loggedUsername, timeSeconds);
        }

        public ArticlePage ClickToRandomArticle(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(randomPageButton, timeSeconds);
            return new ArticlePage();
        }

        public void ClickToSideMenu(int timeSeconds)
        {
            WebDriverExtension.ClickWithAction(openSideMenuButton, timeSeconds);
        }
    }
}