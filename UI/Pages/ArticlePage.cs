using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class ArticlePage : AbstractPage
    {
        private static readonly By editButton = By.CssSelector("#ca-edit>a>span");
        private static readonly By title = By.CssSelector("#firstHeading>span");
        private static readonly By viewHistoryButton = By.CssSelector("#ca-history>a>span");       

        public string GetTitle()
        {
            return WebDriverExtension.GetTextFromElement(title);
        }

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
    }
}