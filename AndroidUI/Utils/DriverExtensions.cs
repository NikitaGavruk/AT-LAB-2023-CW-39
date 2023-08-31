using AndroidUI.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AndroidUI.Utils
{
    public class DriverExtensions
    {
        private static AndroidDriver<IWebElement> driver => DriverFactory.GetDriver();

        private static void WaitElementIsVisible(By locator)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            Wait.Until(driver => driver.FindElement(locator).Displayed);
        }

        public static void ClickToElement(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void SendKeys(By locator, string keys)
        {
            //driver.FindElement(locator).SendKeys(keys);
            WaitElementIsVisible(locator);
            var element = driver.FindElement(locator);
            //element.Click();
            Actions action = new Actions(driver);
            action.SendKeys(element, keys).Perform();
        }

        public static string GetText(By locator) => driver.FindElement(locator).Text;

        public static void PressBack()
        {
            driver.Navigate().Back();
        }

        public static void PressKey(int AndroidKeyCode) 
        {
            //Use AndoidKeyCode.key to find key code
            driver.PressKeyCode(AndroidKeyCode);
        }

        public static void LauncApp()
        {
            driver.LaunchApp();
        }

        public static void CloseApp()
        {
            driver.CloseApp();
        }
        public static void ScrollToElement()
        {
            var elem = driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().text(\"About the Wikipedia app\").instance(0))");
            elem.Click();
        }
    }
}