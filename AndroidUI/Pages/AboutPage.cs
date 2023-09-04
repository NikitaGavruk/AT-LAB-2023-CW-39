using AndroidUI.Utils;
using OpenQA.Selenium;

namespace AndroidUI.Pages
{
    public class AboutPage
    {
        private static readonly By PageTitleLocator = By.XPath("//*[@text='About']");

        public string GetTitle() => DriverExtensions.GetText(PageTitleLocator);
    }
}
