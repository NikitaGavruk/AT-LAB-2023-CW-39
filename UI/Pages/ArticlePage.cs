using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class ArticlePage : AbstractPage
    {
        private static readonly By editButton = By.CssSelector("#ca-edit>a>span");
        private static readonly By title = By.CssSelector("#firstHeading>span");
        private static readonly By viewHistoryButton = By.CssSelector("#ca-history>a>span");       

        public string GetTitle(int timeSeconds)
        {
            return WebDriverExtension.GetTextFromElement(title, timeSeconds);
        }

        public EditHistoryPage ClickToViewHistory(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(viewHistoryButton, timeSeconds);
            return new EditHistoryPage();
        }

        public EditPage ClickToEdit(int timeSeconds)
        {
            WebDriverExtension.ClickOnElement(editButton, timeSeconds);
            return new EditPage();
        }
    }
}