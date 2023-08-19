using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class ListOfWikipediasPage : AbstractPage
    {
        private static readonly By languagesPopUpWindow = By.Id("p-lang-btn");
        private static readonly By russianLanguageButton = By.LinkText("Русский");
        private static readonly By title = By.XPath("//span[@class='mw-page-title-main']");

        public string GetTitle() => WebDriverExtension.GetTextFromElement(title);

        public bool LanguagesPopUpWindowIsVisible() => WebDriverExtension.IsElementVisible(languagesPopUpWindow);
        
        public bool RussianLanguageButtonIsVisible() => WebDriverExtension.IsElementVisible(russianLanguageButton);

        public ListOfWikipediasPage ClickPopUpWindowButton()
        {
            WebDriverExtension.ClickOnElement(languagesPopUpWindow);
            return new ListOfWikipediasPage();
        }

        public ListOfWikipediasPage ClickRussianLanguageButton()
        {
            WebDriverExtension.ClickOnElement(russianLanguageButton);
            return new ListOfWikipediasPage();
        }
    }
}
