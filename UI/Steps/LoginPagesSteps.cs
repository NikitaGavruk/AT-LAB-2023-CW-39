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

        public static MainPage Login(string username, string password)
        {
            loginPage.EnterUsername(username)
            .EnterPassword(password)
            .ClickToLoginButton();
            return new MainPage();
        }
    }
}