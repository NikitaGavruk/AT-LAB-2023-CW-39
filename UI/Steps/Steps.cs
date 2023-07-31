using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;

namespace UI.Steps
{
    public static class Steps
    {
        private static LoginPage loginPage = new LoginPage();
        private static MainPage mainPage = new MainPage();

        public static void Login(string username, string password, int timeSeconds)
        {
            loginPage.EnterUsername(username, timeSeconds);
            loginPage.EnterPassword(password, 1);
            loginPage.ClickToLoginButton(1);
        }

        public static void Logout(int timeSeconds)
        {
            mainPage.CallUserDropdownMenu(timeSeconds);
            mainPage.ClickToLogout(2);
        }

        public static void Search(string searchText, int timeSeconds)
        {
            mainPage.SendKeysToSearchField(searchText, timeSeconds);
            mainPage.ClickToSearchButton(1);
        }
    }
}
