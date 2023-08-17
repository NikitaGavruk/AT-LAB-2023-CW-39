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
        private MainPage _mainPage = new MainPage();
        private LogoutPage _logoutPage;
        private ICustomLogger _logger = new CustomLogger();

        [Given(@"a guest user that not logged in")]
        public void GivenAGuestUserThatNotLoggedIn()
        {
            _logger.LogInfo(LogLevel.Info, "Go to main page");
            var isPageVisible = _mainPage.IsPageVisible();
            _logger.LogInfo(LogLevel.Info, "Check main page loaded");

            Assert.That(isPageVisible, Is.True);
        }

        [When(@"user logs into the system")]
        public void WhenUserLogsIntoTheSystem()
        {
            _logger.LogInfo(LogLevel.Info, "Go to login page");
            _mainPage.ToLoginPage();
            _logger.LogInfo(LogLevel.Info, "User logs into system");
            LoginPagesSteps.Login();
        }

        [Then(@"Main page with username appears")]
        public void ThenMainPageWithUsernameAppears()
        {
            var expectedUsername = TestDataReader.GetTestUsername();

            _logger.LogInfo(LogLevel.Info, "Check username in main page");
            var actualUsername = _mainPage.GetLoggedUsername();

            Assert.That(actualUsername, Is.EqualTo(expectedUsername));
        }

        [When(@"user logs out from system")]
        public void WhenUserLogsOutFromSystem()
        {
            _logger.LogInfo(LogLevel.Info, "User logs out from system");
            _logoutPage = MainPageSteps.Logout();
        }

        [Then(@"user is redirected to main page")]
        public void ThenUserIsRedirectedToMainPage()
        {
            _logger.LogInfo(LogLevel.Info, "User redirect to main page");
            var isPageVisible = _logoutPage.ToMainPage().IsPageVisible();

            Assert.That(isPageVisible, Is.True);
        }
    }
}
