using Core.Utils;
using UI.Pages;

namespace UI.Steps
{
    public static class LoginPagesSteps
    {
        private static LoginPage _loginPage = new LoginPage();

        public static MainPage Login()
        {
            _loginPage.EnterUsername(TestDataReader.GetTestUsername())
            .EnterPassword(TestDataReader.GetTestUserPassword())
            .ClickToLoginButton();

            return new MainPage();
        }
    }
}