using AndroidUI.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidUI.Pages
{
    public class MainPage
    {
        private By inactiveSearchField = By.CssSelector("android.widget.TextView");
        private By activeSearchField = By.CssSelector("android.widget.EditText");
        private By firstSearchPopUp = By.XPath("//*[@resource-id='org.wikipedia:id/page_list_item_title'][1]");

        public MainPage ClickToSearchField()
        {
            DriverExtensions.ClickToElement(inactiveSearchField);
            return new MainPage();
        }

        public MainPage EnterSearchRequest(string searchRequest)
        {
            DriverExtensions.SendKeys(activeSearchField, searchRequest); 
            return new MainPage();
        }

        public MainPage PressEnter()
        {
            DriverExtensions.PressKey(AndroidKeyCode.Keycode_ENTER);
            return new MainPage();
        }

        public MainPage SkipLanguagePopUp()
        {
            try
            {
                DriverExtensions.PressBack();
            }
            catch (WebDriverTimeoutException) { }

            return new MainPage();
        }

        public ArticlePage ClickToFirstSearchPopUp()
        {
            DriverExtensions.ClickToElement(firstSearchPopUp);
            return new ArticlePage();
        }
    }
}
