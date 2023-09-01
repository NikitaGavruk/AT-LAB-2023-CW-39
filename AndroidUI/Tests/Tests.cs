using Microsoft.AspNetCore.Razor.Hosting;

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

        [Test]
        public void SwitchLanguageToRussian()
        {
            mainPage.SkipLanguagePopUp()
                .ClickToSearchField()
                .EnterSearchRequest(ExpectedData.EnglishArticleTitle)
                .PressEnter();

            string isTitleInRussian = languagePage.ClickSearchPopUpBtn()
                .ClickLanguageBtn()
                .ClickSearchFieldBtn()
                .EnterSearchRequest("Russian")
                .ClickLanguagePopUpBtn()
                .GetTitle();
            Assert.That(isTitleInRussian, Is.EqualTo(ExpectedData.ArticleInRussianLang));
        }

        [Test]
        public void SwitchLanguageToUzbek()
        {
            mainPage.SkipLanguagePopUp()
                .ClickToSearchField()
                .EnterSearchRequest(ExpectedData.EnglishArticleTitle)
                .PressEnter();

            string isTitleInUzb = languagePage.ClickSearchPopUpBtn()
                .ClickLanguageBtn()
                .ClickSearchFieldBtn()
                .EnterSearchRequest("Uzbek")
                .ClickLanguagePopUpBtn()
                .GetTitle();
            Assert.That(isTitleInUzb, Is.EqualTo(ExpectedData.ArticleInUzbLang));
        }
    }
}
