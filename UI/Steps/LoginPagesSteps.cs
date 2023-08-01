using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;

namespace UI.Steps
{
    public class LoginPagesSteps
    {
        private static LoginPage loginPage = new LoginPage();

        public static void Login(string username, string password, int timeSeconds)
        {
            loginPage.EnterUsername(username, timeSeconds);
            loginPage.EnterPassword(password, timeSeconds);
            loginPage.ClickToLoginButton(timeSeconds);
        }
    }
}