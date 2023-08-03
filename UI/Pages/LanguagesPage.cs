using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Pages
{
    public class LanguagesPage : AbstractPage
    {
        private static readonly By languagesPopUpWindow = By.Id("p-lang-btn");
        private static readonly By russianLanguageLink = By.LinkText("Русский");
        private static readonly By englishLanguageLink = By.CssSelector(".interwiki-en span");
        private static readonly By uzbekLanguagePage = By.LinkText("Uzbek Wikipedia");
        private static readonly By uzbekWikiPedia = By.LinkText("uz.wikipedia.org");

        public void ClickPopUpWindowButton()
        {
            WebDriverExtension.ClickOnElement(languagesPopUpWindow);
        }

        public void ClickRussianLanguageButton()
        {
            WebDriverExtension.ClickOnElement(russianLanguageLink);
        }

        public void ClickEnglishLanguageButton()
        {
            WebDriverExtension.ClickOnElement(englishLanguageLink);
        }

        public void ClickUzbekLanguageButton()
        {
            WebDriverExtension.ClickOnElement(uzbekLanguagePage);
        }

        public void ClickUzbekWikipediaButton()
        {
            WebDriverExtension.ClickOnElement(uzbekWikiPedia);
        }
    }
}
