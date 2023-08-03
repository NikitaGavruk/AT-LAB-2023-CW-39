using UI.Pages;

namespace UI.Steps
{
    public class LanguagePagesSteps
    {
        private static ListOfWikipediasPage listOfWikipediasPage = new ListOfWikipediasPage();
        private static RussianLanguagePage russianLanguagePage = new RussianLanguagePage();
        private static EnglishLanguagePage englishLanguagePage = new EnglishLanguagePage();
        private static UzbekLanguagePage uzbekLanguagePage = new UzbekLanguagePage();

        public static ListOfWikipediasPage ClickOnListOfWikipediasButton()
        {
            listOfWikipediasPage.ClickPopUpWindowButton();
            return new ListOfWikipediasPage();
        }

        public static ListOfWikipediasPage ClickOnRussianButton()
        {
            listOfWikipediasPage.ClickRussianLanguageButton();
            return new ListOfWikipediasPage();
        }

        public static EnglishLanguagePage ClickOnEnglishButton()
        {
            russianLanguagePage.ClickEnglishLanguageButton();
            return new EnglishLanguagePage();
        }

        public static UzbekLanguagePage ClickOnUzbekButton()
        {
            englishLanguagePage.ClickUzbekLanguageButton();
            uzbekLanguagePage.ClickUzbekWikipediaButton();
            return new UzbekLanguagePage();
        }

    }
}
