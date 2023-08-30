using AndroidUI.Driver;
using Core.enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

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
                    int screenHeight = driver.Manage().Window.Size.Height;
                    int startX = driver.Manage().Window.Size.Width / 2;
                    int startY = (int)(screenHeight * 0.8);
                    int endY = (int)(screenHeight * 0.3);
                    var action = new TouchAction(driver);
                    if (direction == ScrollDirection.Down)
                    {
                        action.Press(startX, startY)
                            .Wait(500)
                            .MoveTo(startX, endY)
                            .Release()
                            .Perform();
                    }
                    else
                    {
                        action.Press(startX, endY)
                            .Wait(500)
                            .MoveTo(startX, startY)
                            .Release()
                            .Perform();
                    }
                }
            }
        }
    }
}
