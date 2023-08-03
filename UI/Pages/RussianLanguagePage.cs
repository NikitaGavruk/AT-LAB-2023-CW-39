using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Pages
{
    public class RussianLanguagePage : AbstractPage
    {
        private static readonly By englishLanguageButton = By.CssSelector(".interwiki-en span");

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
