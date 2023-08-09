using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class WatchlistPage : AbstractPage
    {
        private static readonly By viewWatchlistTab = By.XPath("//span[text()='View and edit watchlist']/ancestor::a");

        public WatchlistPage SwitchToViewWachlistTab()
        {
            WebDriverExtension.ClickOnElement(viewWatchlistTab);
            return new WatchlistPage();
        }

        public bool IsArticleInList(string articleTitle)
        {
            By article = By.XPath($"//a[@title='{articleTitle}']");
            return WebDriverExtension.IsElementVisible(article);
        }
    }
}
