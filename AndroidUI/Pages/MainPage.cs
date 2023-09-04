using AndroidUI.Utils;
using Core.enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidUI.Pages
{
    public class MainPage
    {
        // Find article test locators
        private By inactiveSearchField = By.CssSelector("android.widget.TextView");
        private By activeSearchField = By.XPath("//*[@resource-id='org.wikipedia:id/search_src_text']");
        private By searchPopUps = By.XPath("//*[@resource-id='org.wikipedia:id/page_list_item_title']");

        // Display about page test locators
        private static readonly By SkipTextLocator = By.Id("org.wikipedia:id/fragment_onboarding_skip_button");
        private static readonly By MenuIconLocator = By.Id("org.wikipedia:id/menu_icon");
        private static readonly By LoginLinkLocator = By.Id("org.wikipedia:id/main_drawer_account_container");
        private static readonly By SaveNoButtonLocator = By.Id("android:id/autofill_dialog_no");
        private static readonly By SettingsLinkLocator = By.Id("org.wikipedia:id/main_drawer_settings_container");
        private static readonly By PromptBoxRejectLocator = By.Id("android:id/button2");

        // Add to watchlist locators
        private By randomizer = By.XPath("//*[contains(@text,'More random articles')]");

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

        // Display About Test Methods
        public MainPage ClickSkipText()
        {
            DriverExtensions.ClickToElement(SkipTextLocator);
            return new MainPage();
        }

        public MainPage ClickMenu()
        {
            DriverExtensions.ClickToElement(MenuIconLocator);
            return new MainPage();
        }
        public SettingsPage ClickSettings()
        {
            DriverExtensions.ClickToElement(SettingsLinkLocator);
            return new SettingsPage();
        }

        public RandomizerPage OpenRandomizerPage()
        {
            DriverExtensions.ScrollToElement(randomizer, ScrollDirection.Down);
            DriverExtensions.ClickToElement(randomizer);
            return new RandomizerPage();
        }
    }
}