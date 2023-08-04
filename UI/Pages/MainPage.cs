using OpenQA.Selenium;
using UI.Utils;
using UI.WebDriver;

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
        private static readonly By userDropdownMenu = By.CssSelector("#vector-user-links-dropdown");
        private static readonly By logoutButton = By.Id("pt-logout");
        private static readonly By loggedUsername = By.CssSelector("#pt-userpage-2>a>span");
        private static readonly By aboutWikipediaLink = By.Id("n-aboutsite");

        public bool IsPageVisible()
        {
            return WebDriverExtension.IsElementVisible(title);
        }

        public LoginPage ToLoginPage()
        {
            WebDriverExtension.ClickOnElement(loginButton);
            return new LoginPage();
        }

        public MainPage CallUserDropdownMenu()
        {
            WebDriverExtension.ClickOnElement(userDropdownMenu);
            return new MainPage();
        }

        public LogoutPage ClickToLogout()
        {
            WebDriverExtension.ClickOnElement(logoutButton);
            return new LogoutPage();
        }

        public MainPage SendKeysToSearchField(string searchText)
        {
            WebDriverExtension.SendKeysToElement(searchField, searchText);
            return new MainPage();
        }

        public ArticlePage ClickToSearchButton()
        {
            WebDriverExtension.ClickOnElement(searchButton);
            return new ArticlePage();
        }

        public string GetLoggedUsername()
        {
            return WebDriverExtension.GetTextFromElement(loggedUsername);
        }

        public ArticlePage ClickToRandomArticle()
        {
            WebDriverExtension.ClickOnElement(randomPageButton);
            return new ArticlePage();
        }

        public MainPage ClickToSideMenu()
        {
            WebDriverExtension.ClickWithAction(openSideMenuButton);
            return new MainPage();
        }

        public AboutPage ClickAboutWikipediaLink()
        {
            WebDriverExtension.ClickOnElement(aboutWikipediaLink);
            return new AboutPage();
        }
    }
}