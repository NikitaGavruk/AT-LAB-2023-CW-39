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
    }
}
