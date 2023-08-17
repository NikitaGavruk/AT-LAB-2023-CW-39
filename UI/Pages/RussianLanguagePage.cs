using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class RussianLanguagePage : AbstractPage
    {
        private static readonly By englishLanguageButton = By.CssSelector(".interwiki-en span");

        public bool EnglishLanguageButtonIsVisible() => WebDriverExtension.IsElementVisible(englishLanguageButton);
             
        public RussianLanguagePage ClickEnglishLanguageButton()
        {
            WebDriverExtension.ClickOnElement(englishLanguageButton);
            return new RussianLanguagePage();
        }
    }
}
