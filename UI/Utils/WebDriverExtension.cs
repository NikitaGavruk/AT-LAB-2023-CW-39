using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using UI.WebDriver;
using System;

namespace UI.Utils
{
    public static class WebDriverExtension
    {
        private static void WaitElementIsVisible(By locator, int timeSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(timeSeconds));
            wait.Until(driver => driver.FindElement(locator).Displayed);
        }
        public static void ClickOnElement(By locator, int timeSeconds)
        {
            WaitElementIsVisible(locator, timeSeconds);
            Browser.GetDriver().FindElement(locator).Click();
        }

        public static void SendKeysToElement(By locator, string text, int timeSeconds)
        {
            WaitElementIsVisible(locator, timeSeconds);
            Browser.GetDriver().FindElement(locator).SendKeys(text);
        }

        public static void ClickOnEnter(By locator, int timeSeconds)
        {
            WaitElementIsVisible(locator, timeSeconds);
            Browser.GetDriver().FindElement(locator).SendKeys(Keys.Enter);
        }        

        public static string GetTextFromElement(By locator, int timeSeconds)
        {
            WaitElementIsVisible(locator, timeSeconds);
            return Browser.GetDriver().FindElement(locator).Text;
        }

        public static bool IsElementVisible(By locator, int timeSeconds)
        {
            try
            {
                WaitElementIsVisible(locator, timeSeconds);
                return Browser.GetDriver().FindElement(locator).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public static string GetAttributeValueFromElement(By locator, string attribute, int timeSeconds)
        {
            WaitElementIsVisible(locator, timeSeconds);
            return Browser.GetDriver().FindElement(locator).GetAttribute(attribute);
        }

        public static void ClearField(By locator, int timeSeconds)
        {
            WaitElementIsVisible(locator, timeSeconds);
            Browser.GetDriver().FindElement(locator).Clear();
        }

        public static IWebElement GetElement(By locator, int timeSeconds)
        {
            WaitElementIsVisible(locator, timeSeconds);
            return Browser.GetDriver().FindElement(locator);
        }

        public static void ClickWithAction(By locator, int timeSeconds)
        {            
            var elementToClick = GetElement(locator, timeSeconds);
            Browser.GetActions().MoveToElement(elementToClick).Click().Perform();
        }
    }
}
