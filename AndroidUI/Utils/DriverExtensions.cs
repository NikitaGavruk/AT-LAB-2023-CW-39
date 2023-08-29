using AndroidUI.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidUI.Utils
{
    public class DriverExtensions
    {
        private static AndroidDriver<IWebElement> driver => DriverFactory.GetDriver();

        public static void ClickToElement(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void SendKeys(By locator, string keys)
        {
            driver.FindElement(locator).SendKeys(keys);
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
    }
}
