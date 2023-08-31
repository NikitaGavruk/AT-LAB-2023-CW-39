namespace AndroidUI.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
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

        [Test]
        public void DisplayAboutPageTest()
        {
            var result = mainPage.ClickSkipText()
               .ClickMenu()
               .ClickSettings()
               .ScrollToElement()
               .ClickAboutPageLink()
               .GetTitle();

            Assert.That(result, Is.EqualTo("About"));
        }
    }
}