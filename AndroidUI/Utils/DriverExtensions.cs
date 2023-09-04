using AndroidUI.Driver;
using Core.enums;
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

        public static void ScrollToElement(By element, ScrollDirection direction)
        {
            bool elementFound = false;
            while (!elementFound)
            {
                try
                {
                    var result = driver.FindElement(element);

                    if (result != null)
                    {
                        elementFound = true;
                    }
                }
                catch (Exception)
                {
                    if (direction == ScrollDirection.Down)
                    {
                        driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollForward()");
                    }
                    else
                    {
                        driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollBackward()");
                    }
                }
            }
        }
    }
}
