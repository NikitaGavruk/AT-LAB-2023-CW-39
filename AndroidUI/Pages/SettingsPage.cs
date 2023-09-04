using AndroidUI.Utils;
using OpenQA.Selenium;

namespace AndroidUI.Pages
{
    public class SettingsPage
    {
        private static readonly By AboutPageLocator = By.XPath("//*[@class='android.widget.TextView'][contains(@text, \"Wikipedia app\")]");

        public SettingsPage ScrollToElement()
        {
            DriverExtensions.ScrollToElement();
            return new SettingsPage();
        }

        public AboutPage ClickAboutPageLink()
        {
            DriverExtensions.ClickToElement(AboutPageLocator);
            return new AboutPage();
        }
    }
}