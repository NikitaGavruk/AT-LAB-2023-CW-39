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
                ClickToSearchPopup(ExpectedData.ArticleToBeSearched).
                GetTitle();

            Assert.That(actualTitle, Is.EqualTo(ExpectedData.ArticleTitle));
        }
    }
}
