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
    public class DisplayAboutPageStepDefinitions
    {
        private MainPage _mainPage = new MainPage();
        private AboutPage _aboutPage = new AboutPage();
        private ICustomLogger _logger = new CustomLogger();
        
        [Given(@"a user logs into the account")]
        public void GivenAUserLogsIntoTheAccount()
        {
            _logger.LogInfo(LogLevel.Info, "Go to login page");
            _mainPage.ToLoginPage();
            _logger.LogInfo(LogLevel.Info, "Log into an account");
            LoginPagesSteps.Login();
        }

        [When(@"user clicks about link in menu")]
        public void WhenUserClicksAboutLinkInMenu()
        {
            _logger.LogInfo(LogLevel.Info, "Go to About page");
            _mainPage.ClickAboutWikipediaLink();
        }

        [Then(@"user should see the page with ""(.*)"" heading")]
        public void ThenUserIsDirectedToCorrectPage(string heading)
        {
            _logger.LogInfo(LogLevel.Info, "Verify About Page is displayed");
            Assert.AreEqual(heading, _aboutPage.GetActualHeading());
        }
    }
}
