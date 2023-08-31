using AndroidUI.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidUI.Pages
{
    public class MainPage
    {
        private By inactiveSearchField = By.CssSelector(".android.widget.TextView");
        private By activeSearchField = By.XPath("//*[@resource-id='org.wikipedia:id/search_src_text']");
        private By searchPopUps = By.XPath("//*[@resource-id='org.wikipedia:id/page_list_item_title']");

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

        public ArticlePage ClickToSearchPopup(string title)
        {
            var searchResults = DriverExtensions.GetElements(searchPopUps);

            var articleLinks = from element in searchResults
                         where element.Text == title
                         select element;

            if (articleLinks.Count() == 0)
                throw new InvalidSelectorException($"Link with \"{title}\" text not found");

            articleLinks.First().Click();  

            return new ArticlePage();
        }
    }
}
