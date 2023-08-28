using AndroidUI.Driver;
using AndroidUI.Pages;
using AndroidUI.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUI.Tests
{
    [TestFixture]
    public class Tests
    {
        private AndroidDriver<IWebElement> driver;
        private MainPage mainPage = new MainPage();

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void FindArticle()
        {
            string actualTitle = mainPage.SkipLanguagePopUp().
                ClickToSearchField().
                EnterSearchRequest("Mikhail Lomonosov").
                PressEnter().
                ClickToFirstSearchPopUp().
                GetTitle();

            Assert.That(actualTitle, Is.EqualTo("Mikhail Lomonosov"));
        }

        [TearDown]
        public void Quit()
        {
            DriverFactory.ExitDriver();
        }
    }
}
