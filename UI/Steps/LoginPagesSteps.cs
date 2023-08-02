using Core;
using Core.Model;
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

        public static MainPage Login()
        {
            loginPage.EnterUsername(TestDataReader.GetTestUsername())
            .EnterPassword(TestDataReader.GetTestUserPassword())
            .ClickToLoginButton();
            return new MainPage();
        }
    }
}