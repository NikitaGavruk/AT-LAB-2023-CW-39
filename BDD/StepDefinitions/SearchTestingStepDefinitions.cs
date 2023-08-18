using BDD.Hooks;
using Core.enums;
using Core.Interfaces;
using Core.Utils;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using UI.Pages;
using UI.Steps;

namespace BDD.StepDefinitions
{ 
    [Binding]    
    public class SearchTestingStepDefinitions
    {
        private MainPage mainPage = new MainPage();       
        private ArticlePage articlePage = new ArticlePage();
        private ICustomLogger logger = new CustomLogger();

        [Given(@"I should see the search bar")]
        public void GivenIShouldSeeTheSearchBar()
        {
            logger.LogInfo(LogLevel.Info, "Checking is search bar visible");
            Assert.That(mainPage.IsSearchFieldVisible(), Is.True);
        }

        [When(@"I execute search with a given ""([^""]*)""")]
        public void WhenIExecuteSearchWithAGiven(string searchRequest)
        {
            logger.LogInfo(LogLevel.Info, "Execute search with a given search request");
            MainPageSteps.Search(searchRequest);
        }

        [Then(@"I should see article page with ""([^""]*)"" title")]
        public void ThenIShouldSeeArticlePageWithTitle(string searchRequest)
        {
            logger.LogInfo(LogLevel.Info, "Checking is article's title correct");
            Assert.That(articlePage.GetTitle(), Is.EqualTo(searchRequest));
        }
    }
}
