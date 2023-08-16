using Core.enums;
using Core.Interfaces;
using Core.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UI.Pages;
using UI.Steps;

namespace BDD.StepDefinitions
{
    [Binding]
    public class LoginAndLogoutStepDefinitions
    {
        private MainPage mainPage = new MainPage();
        private LoginPage loginPage;
        private LogoutPage logoutPage;
        private ICustomLogger logger = new CustomLogger();

        [Given(@"a guest user that not logged in")]
        public void GivenAGuestUserThatNotLoggedIn()
        {
            logger.LogInfo(LogLevel.Info, "Go to main page");
            var isPageVisible = mainPage.IsPageVisible();
            logger.LogInfo(LogLevel.Info, "Check main page loaded");

            Assert.That(isPageVisible, Is.True);
        }

        [When(@"user logs into the system")]
        public void WhenUserLogsIntoTheSystem()
        {
            logger.LogInfo(LogLevel.Info, "Go to login page");
            loginPage = mainPage.ToLoginPage();
            logger.LogInfo(LogLevel.Info, "User logs into system");
            LoginPagesSteps.Login();
        }

        [Then(@"Main page with username appears")]
        public void ThenMainPageWithUsernameAppears()
        {
            var expectedUsername = TestDataReader.GetTestUsername();

            logger.LogInfo(LogLevel.Info, "Check username in main page");
            var actualUsername = mainPage.GetLoggedUsername();

            Assert.That(actualUsername, Is.EqualTo(expectedUsername));
        }

        [When(@"user logs out from system")]
        public void WhenUserLogsOutFromSystem()
        {
            logger.LogInfo(LogLevel.Info, "User logs out from system");
            logoutPage = MainPageSteps.Logout();
        }

        [Then(@"user is redirected to main page")]
        public void ThenUserIsRedirectedToMainPage()
        {
            logger.LogInfo(LogLevel.Info, "User redirect to main page");
            var isPageVisible = logoutPage.ToMainPage().IsPageVisible();

            Assert.That(isPageVisible, Is.True);
        }
    }
}
