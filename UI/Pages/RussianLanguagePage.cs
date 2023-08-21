using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class RussianLanguagePage : AbstractPage
    {
        private static readonly By englishLanguageButton = By.CssSelector(".interwiki-en span");
        private static readonly By title = By.XPath("//span[@class='mw-page-title-main']");

        public string GetTitle()
        {
            return WebDriverExtension.GetTextFromElement(title);
        }

        public bool EnglishLanguageButtonIsVisible()
        {
            return WebDriverExtension.IsElementVisible(englishLanguageButton);
        }

        public RussianLanguagePage ClickEnglishLanguageButton()
        {
            WebDriverExtension.ClickOnElement(englishLanguageButton);
            return new RussianLanguagePage();
        }
    }
}
