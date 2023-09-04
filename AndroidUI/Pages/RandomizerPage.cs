using AndroidUI.Utils;
using OpenQA.Selenium;

namespace AndroidUI.Pages
{
    public class RandomizerPage
    {
        private By randomArticle = By.Id("org.wikipedia:id/articleTitle");

        public ArticlePage OpenRandomArticle()
        {
            DriverExtensions.ClickToElement(randomArticle);
            return new ArticlePage();
        }
    }
}
