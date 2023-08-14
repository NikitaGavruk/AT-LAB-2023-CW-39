using UI.Pages;

namespace UI.Steps
{
    public static class LanguagePagesSteps
    {
        private static ListOfWikipediasPage _listOfWikipediasPage = new ListOfWikipediasPage();
        private static RussianLanguagePage _russianLanguagePage = new RussianLanguagePage();
        private static EnglishLanguagePage _englishLanguagePage = new EnglishLanguagePage();
        private static UzbekLanguagePage _uzbekLanguagePage = new UzbekLanguagePage();

        public static ListOfWikipediasPage ClickOnListOfWikipediasButton()
        {
            _listOfWikipediasPage.ClickPopUpWindowButton();
            return new ListOfWikipediasPage();
        }

        public static ListOfWikipediasPage ClickOnRussianButton()
        {
            _listOfWikipediasPage.ClickRussianLanguageButton();
            return new ListOfWikipediasPage();
        }

        public static EnglishLanguagePage ClickOnEnglishButton()
        {
            _russianLanguagePage.ClickEnglishLanguageButton();
            return new EnglishLanguagePage();
        }

        public static UzbekLanguagePage ClickOnUzbekButton()
        {
            _englishLanguagePage.ClickUzbekLanguageButton();
            _uzbekLanguagePage.ClickUzbekWikipediaButton();
            return new UzbekLanguagePage();
        }

    }
}
