using NUnit.Framework;
using UI.Pages;
using UI.Steps;
using Core.enums;
using Core.Utils;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace UI.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Test")]
    [AllureFeature("Test Features")]
    [AllureEpic(".NET Automation Lab")]
    public class Test : BaseTest
    {
        private static MainPage mainPage = new MainPage();

        [Test(Description = "Logins and logs out from account")]
        [AllureStory("Logins and logs out from account")]
        [AllureStep("Logins and logs out from account")]
        public void LoginAndLogout()
        {
            CustomLogger.LogInfo(LogLevel.Info, "Go to Login page");
            mainPage.ToLoginPage();
            CustomLogger.LogInfo(LogLevel.Info, "Login to account");
            string actualUsername = LoginPagesSteps.Login()
                .GetLoggedUsername();
            CustomLogger.LogInfo(LogLevel.Info, "Verify username is right");
            Assert.That(actualUsername, Is.EqualTo(TestDataReader.GetTestUsername()));

            CustomLogger.LogInfo(LogLevel.Info, "Logout from account");
            var hasReturnedToMainPage = MainPageSteps.Logout()
                .ToMainPage()
                .IsPageVisible();

            CustomLogger.LogInfo(LogLevel.Info, "Verify Main Page is visible");
            Assert.That(hasReturnedToMainPage, Is.True);
        }

        [Test(Description = "Types something, searches it and finds article about it")]
        [AllureStory("Types something, searches it and finds article about it")]
        [AllureStep("Types something, searches it and finds article about it")]
        public void FindArticle()
        {
            CustomLogger.LogInfo(LogLevel.Info, "Go to Main Page");
            string expectedTitle = ExpectedData.ArticleToBeSearched;
            CustomLogger.LogInfo(LogLevel.Info, $"Start search {expectedTitle}");
            string actualTitle = MainPageSteps.Search(expectedTitle)
                .GetTitle();
            CustomLogger.LogInfo(LogLevel.Info, "Verify that loaded right article page");
            Assert.That(expectedTitle, Is.EqualTo(actualTitle));
        }

        [Test(Description = "Checks the article edit history")]
        [AllureStory("Checks the article edit history")]
        [AllureStep("Checks the article edit history")]
        public void CheckArticleEditHistory()
        {
            CustomLogger.LogInfo(LogLevel.Info, "Go to Login page");
            mainPage.ToLoginPage();
            CustomLogger.LogInfo(LogLevel.Info, "Login to account");
            string actualUsername = LoginPagesSteps.Login()
                .GetLoggedUsername();
            CustomLogger.LogInfo(LogLevel.Info, "Verify username is right");
            Assert.That(actualUsername, Is.EqualTo(TestDataReader.GetTestUsername()));

            CustomLogger.LogInfo(LogLevel.Info, "Click to random article");
            bool IsEditPageVisible = mainPage.ClickToRandomArticle()
                .ClickToViewHistory()
                .IsPageVisible();
            CustomLogger.LogInfo(LogLevel.Info, "Verify Edit page is visible");
            Assert.That(IsEditPageVisible, Is.True);
        }

        [Test(Description = "Checks if user logged or not")]
        [AllureStory("Checks if user logged or not")]
        [AllureStep("Checks if user logged or not")]
        public void CheckNotLoggedWarningOnEditPage()
        {
            CustomLogger.LogInfo(LogLevel.Info, "Go to Main page");
            mainPage.OpenSideMenu();
            bool IsNotLoggedWarningDisplayed = mainPage.ClickToRandomArticle()
                .ClickToEdit()
                .IsNotLoggedWarningDisplayed();
            CustomLogger.LogInfo(LogLevel.Info, "Verify warning for not logged user displayed");
            Assert.That(IsNotLoggedWarningDisplayed, Is.True);
        }

        [Test(Description = "Checks every single language pages are working or not")]
        [AllureStory("Checks every single language pages are working or not")]
        [AllureStep("Checks every single language pages are working or not")]
        public void CheckSwitchLanguages()
        {
            Driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/List_of_Wikipedias");
            CustomLogger.LogInfo(LogLevel.Info, "Go to Languages Page");
            string expectedTitleOfRussianLanguage = LanguagePagesSteps.ClickOnListOfWikipediasButton()
                .ClickRussianLanguageButton()
                .GetTitle();
            string actualTitleOfRussianLanguage = ExpectedData.TitleOfRussianLanguage;
            Assert.That(actualTitleOfRussianLanguage, Is.EqualTo(expectedTitleOfRussianLanguage));
            CustomLogger.LogInfo(LogLevel.Info, "Go to Language categories page in Russian");
            string expectedTitleOfEnglishLanguage = LanguagePagesSteps.ClickOnEnglishButton()
                .GetTitle();
            string actualTitleOfEnglishLanguage = ExpectedData.TitleOfEnglishLanguage;
            Assert.That(actualTitleOfEnglishLanguage, Is.EqualTo(expectedTitleOfEnglishLanguage));
            CustomLogger.LogInfo(LogLevel.Info, "Go to Language categories page in English");
            string expectedTitleOfUzbekLanguage = LanguagePagesSteps.ClickOnUzbekButton()
                .GetTitle();
            string actualTitleOfUzbekLanguage = ExpectedData.TitleOfUzbekLanguage;
            CustomLogger.LogInfo(LogLevel.Info, "Verify the page is Uzbek version of Wikipedia");
            Assert.That(actualTitleOfUzbekLanguage, Is.EqualTo(expectedTitleOfUzbekLanguage));
        }

        [Test(Description = "It adds article to watch list")]
        [AllureStory("It adds article to watch list")]
        [AllureStep("It adds article to watch list")]
        public void AddToWatchlist()
        {
            CustomLogger.LogInfo(LogLevel.Info, "Go to Login page");
            mainPage.ToLoginPage();
            CustomLogger.LogInfo(LogLevel.Info, "Login to account");
            string actualUsername = LoginPagesSteps.Login()
            .GetLoggedUsername();
            CustomLogger.LogInfo(LogLevel.Info, "Verify username is right");
            Assert.That(actualUsername, Is.EqualTo(TestDataReader.GetTestUsername()));

            CustomLogger.LogInfo(LogLevel.Info, "Click to random article and get its title");
            string articleTitle = mainPage.ClickToRandomArticle()
                .GetTitle();

            CustomLogger.LogInfo(LogLevel.Info, "Check if article is on watchlist");
            var isArticleOnList = ArticlePageSteps.AddToWatchlist()
                .SwitchToViewWachlistTab()
                .IsArticleInList(articleTitle);
            Assert.That(isArticleOnList, Is.True);
        }
        
        [Test(Description = "Checks if page is displayed or not")]
        [AllureStory("Checks if page is displayed or not")]
        [AllureStep("Checks if page is displayed or not")]
        public void DisplayAboutPageTest()
        {
            CustomLogger.LogInfo(LogLevel.Info, "Go to Login page");
            MainPage.ToLoginPage();
            CustomLogger.LogInfo(LogLevel.Info, "Log into an account");
            LoginPagesSteps.Login();
            CustomLogger.LogInfo(LogLevel.Info, "Go to About page");
            MainPage.ClickAboutWikipediaLink();

            CustomLogger.LogInfo(LogLevel.Info, "Verify About Page is displayed");
            Assert.AreEqual(ExpectedData.HeadingInAboutPage, AboutPage.GetActualHeading());
        }
    }
}
