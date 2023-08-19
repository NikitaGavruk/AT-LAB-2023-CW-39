using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class ArticlePage : AbstractPage
    {
        private static readonly By editButton = By.CssSelector("#ca-edit>a>span");
        private static readonly By title = By.CssSelector("#firstHeading>span");
        private static readonly By viewHistoryButton = By.CssSelector("#ca-history>a>span");
        private static readonly By addToWatchlist = By.CssSelector("#ca-watch>a>span");
        private static readonly By watchlistLink = By.CssSelector("#pt-watchlist-2>a");

        public string GetTitle() => WebDriverExtension.GetTextFromElement(title);

        public EditHistoryPage ClickToViewHistory()
        {
            WebDriverExtension.ClickOnElement(viewHistoryButton);
            return new EditHistoryPage();
        }

        public EditPage ClickToEdit()
        {
            WebDriverExtension.ClickOnElement(editButton);
            return new EditPage();
        }

        public ArticlePage AddToWatchlist()
        {
            WebDriverExtension.ClickOnElement(addToWatchlist);
            return new ArticlePage();
        }

        public WatchlistPage NavigateToWatchlist()
        {
            WebDriverExtension.ClickOnElement(watchlistLink);
            return new WatchlistPage();
        }
    }
}
