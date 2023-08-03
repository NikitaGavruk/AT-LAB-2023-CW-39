using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class UzbekLanguagePage : AbstractPage
    {
        private static readonly By uzbekWikiPedia = By.LinkText("uz.wikipedia.org");
        private static readonly By title = By.XPath("(//a[@href='/wiki/Vikipediya'])[1]");

        public string GetTitle()
        {
            return WebDriverExtension.GetTextFromElement(title);
        }

        public bool UzbekWikipediaButtonIsVisible()
        {
            return WebDriverExtension.IsElementVisible(uzbekWikiPedia);
        }

        public UzbekLanguagePage ClickUzbekWikipediaButton()
        {
            WebDriverExtension.ClickOnElement(uzbekWikiPedia);
            return new UzbekLanguagePage();
        }
    }
}
