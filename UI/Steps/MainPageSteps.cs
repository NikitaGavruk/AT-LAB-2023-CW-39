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

        public static LogoutPage Logout(int timeSeconds)
        {
            mainPage.CallUserDropdownMenu(timeSeconds);
            mainPage.ClickToLogout(timeSeconds);
            return new LogoutPage();
        }

        public static ArticlePage Search(string searchText, int timeSeconds)
        {
            mainPage.SendKeysToSearchField(searchText, timeSeconds);
            mainPage.ClickToSearchButton(timeSeconds);
            return new ArticlePage();
        }
    }
}
