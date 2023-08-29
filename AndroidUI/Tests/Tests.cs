using AndroidUI.Driver;
using AndroidUI.Pages;
using AndroidUI.Utils;
using Core.enums;
using Core.Model;
using Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidUI.Tests
{
    [TestFixture]
    public class Tests
    {
        private AndroidDriver<IWebElement> driver;
        private MainPage mainPage = new MainPage();
        private ExpectedDataModel ExpectedData;

        [SetUp]
        public void SetUp()
        {
            ExpectedData = ExpectedDataReader.GetExpectedData<ExpectedDataModel>(Resources.ExpectedData);
        }

        [Test]
        public void FindArticle()
        {
            string actualTitle = mainPage.SkipLanguagePopUp().
                ClickToSearchField().
                EnterSearchRequest(ExpectedData.ArticleToBeSearched).
                PressEnter().
                ClickToFirstSearchPopUp().
                GetTitle();

            Assert.That(actualTitle, Is.EqualTo(ExpectedData.ArticleTitle));
        }

        [TearDown]
        public void Quit()
        {
            DriverFactory.ExitDriver();
        }
    }
}
