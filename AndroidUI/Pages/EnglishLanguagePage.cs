using AndroidUI.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUI.Pages
{
    public class EnglishLanguagePage
    {
        private By title = By.CssSelector(".android.widget.TextView");
        private By searchPopUpBtn = By.Id("org.wikipedia:id/page_list_item_title");
        private By languageBtn = By.Id("org.wikipedia:id/page_language");
        private By searchFieldBtn = By.Id("org.wikipedia:id/menu_search_language");
        private By searchField = By.Id("org.wikipedia:id/search_src_text");
        private By languagePopUpBtn = By.Id("org.wikipedia:id/localized_language_name");

        public string GetTitle() => DriverExtensions.GetText(title);

        public EnglishLanguagePage ClickSearchPopUpBtn()
        {
            DriverExtensions.ClickToElement(searchPopUpBtn);
            return new EnglishLanguagePage();
        }

        public EnglishLanguagePage ClickLanguageBtn()
        {
            DriverExtensions.ClickToElement(languageBtn);
            return new EnglishLanguagePage();
        }

        public EnglishLanguagePage ClickSearchFieldBtn()
        {
            DriverExtensions.ClickToElement(searchFieldBtn);
            return new EnglishLanguagePage();
        }

        public EnglishLanguagePage EnterSearchRequest(string searchRequest)
        {
            DriverExtensions.SendKeys(searchField, searchRequest);
            return new EnglishLanguagePage();
        }

        public EnglishLanguagePage ClickLanguagePopUpBtn()
        {
            DriverExtensions.ClickToElement(languagePopUpBtn);
            return new EnglishLanguagePage(); // switch to Russian/Uzbek language
        }
    }
}
