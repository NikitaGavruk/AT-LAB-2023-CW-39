using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;

namespace UI.Steps
{
    public class MainPageSteps
    {
        private static MainPage mainPage = new MainPage();
        
        public static LogoutPage Logout()
        {
            mainPage.CallUserDropdownMenu()
            .ClickToLogout();
            return new LogoutPage();
        }

        public static ArticlePage Search(string searchText)
        {
            mainPage.SendKeysToSearchField(searchText)
            .ClickToSearchButton();
            return new ArticlePage();
        }
    }
}
