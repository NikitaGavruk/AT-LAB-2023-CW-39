using UI.Pages;

namespace UI.Steps
{
    public static class MainPageSteps
    {
        private static MainPage _mainPage = new MainPage();
        
        public static LogoutPage Logout()
        {
            _mainPage.CallUserDropdownMenu()
            .ClickToLogout();
            return new LogoutPage();
        }

        public static ArticlePage Search(string searchText)
        {
            _mainPage.SendKeysToSearchField(searchText)
            .SendEnterToSearchField();
            return new ArticlePage();
        }
    }
}
