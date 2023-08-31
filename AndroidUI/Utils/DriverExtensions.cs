using AndroidUI.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;

namespace AndroidUI.Utils
{
    public static class DriverExtensions
    {
        private static AndroidDriver<IWebElement> driver => DriverFactory.GetDriver();

        public static void ClickToElement(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void SendKeys(By locator, string keys)
        {
            var element = GetElement(locator);
            element.Click();
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
        public static IWebElement GetElement(By locator) => driver.FindElement(locator);
    }
}
