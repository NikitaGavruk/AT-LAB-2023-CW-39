using Core.enums;
using Core.Interfaces;
using Core.Model;
using Core.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using UI.Pages;
using UI.Steps;
using UI.WebDriver;

namespace BDD.StepDefinitions
{
    [Binding]
    public class SwitchLanguageStepDefinitions
    {
        private ListOfWikipediasPage listOfWikipediasPage = new ListOfWikipediasPage();
        private RussianLanguagePage russianLanguagePage = new RussianLanguagePage();
        private EnglishLanguagePage englishLanguagePage = new EnglishLanguagePage();
        private UzbekLanguagePage uzbekLanguagePage = new UzbekLanguagePage();
        private ExpectedDataModel expectedData = new ExpectedDataModel();
        private ICustomLogger logger = new CustomLogger();

        [Given(@"the user is on the Wikipedia website")]
        public void GivenTheUserIsOnTheWikipediaWebsite()
        {
            Browser.NavigateTo("https://en.wikipedia.org/wiki/List_of_Wikipedias");
            logger.LogInfo(Core.enums.LogLevel.Info, "Checking if website in the right path");
            Assert.That(listOfWikipediasPage.GetTitle, Is.EqualTo("List of Wikipedias"));
        }

        [When(@"the user switches to Russian language")]
        public void WhenTheUserSwitchesToRussianLanguage()
        {
            logger.LogInfo(Core.enums.LogLevel.Info, "Go to Russian language");
            LanguagePagesSteps.ClickOnListOfWikipediasButton().ClickRussianLanguageButton();
        }

        [Then(@"the page language should be Russian")]
        public void ThenThePageLanguageShouldBeRussian()
        {
            logger.LogInfo(Core.enums.LogLevel.Info, "Checking if page loaded");
            Assert.That(russianLanguagePage.GetTitle, Is.EqualTo("Языковые разделы Википедии"));
        }

        [When(@"the user switches to English language")]
        public void WhenTheUserSwitchesToEnglishLanguage()
        {
            logger.LogInfo(Core.enums.LogLevel.Info, "Go to English language");
            LanguagePagesSteps.ClickOnEnglishButton();
        }

        [Then(@"the page language should be English")]
        public void ThenThePageLanguageShouldBeEnglish()
        {
            logger.LogInfo(Core.enums.LogLevel.Info, "Checking if page loaded");
            Assert.That(englishLanguagePage.GetTitle(), Is.EqualTo("List of Wikipedias"));
        }

        [When(@"the user switches to Uzbek language")]
        public void WhenTheUserSwitchesToUzbekLanguage()
        {
            logger.LogInfo(Core.enums.LogLevel.Info, "Go to Uzbek language");
            LanguagePagesSteps.ClickOnUzbekButton();
        }

        [Then(@"the page language should be Uzbek")]
        public void ThenThePageLanguageShouldBeUzbek()
        {
            logger.LogInfo(Core.enums.LogLevel.Info, "Checking if page loaded");
            Assert.That(uzbekLanguagePage.GetTitle(), Is.EqualTo("Vikipediyaga"));
        }
    }
}
