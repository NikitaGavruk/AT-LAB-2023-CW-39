using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class AboutPage : AbstractPage
    {
        private static readonly By aboutPageHeading = By.Id("firstHeading");

        public string GetActualHeading()
        {
           return WebDriverExtension.GetTextFromElement(aboutPageHeading);
        }
    }
}
