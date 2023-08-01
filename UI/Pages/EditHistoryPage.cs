using OpenQA.Selenium;
using UI.Utils;

namespace UI.Pages
{
    public class EditHistoryPage : AbstractPage
    {
        private static readonly By title = By.CssSelector("#firstHeading");

        public bool IsPageVisible(int timeSeconds)
        {
            return WebDriverExtension.IsElementVisible(title, timeSeconds);
        }
    }
}