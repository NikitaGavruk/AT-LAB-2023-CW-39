using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using UI.WebDriver;
using System;

namespace UI.Utils
{
    public static class WebDriverExtension
    {
        public static WebDriverWait Wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(int.Parse(Configuration.ElementTimeout)));

        private static void WaitElementIsVisible(By locator)
        {
            Wait.Until(driver => driver.FindElement(locator).Displayed);
        }

        private static void WaitElementIsClickable(By locator)
        {
            Wait.Until(driver => driver.FindElement(locator).Enabled);
        }
        public static void ClickOnElement(By locator)
        {
            WaitElementIsVisible(locator);
            Browser.GetDriver().FindElement(locator).Click();
        }

        public static void SendKeysToElement(By locator, string text)
        {
            WaitElementIsVisible(locator);
            Browser.GetDriver().FindElement(locator).SendKeys(text);
        }

        public static void ClickOnEnter(By locator)
        {
            WaitElementIsVisible(locator);
            Browser.GetDriver().FindElement(locator).SendKeys(Keys.Enter);
        }        

        public static string GetTextFromElement(By locator)
        {
            WaitElementIsVisible(locator);
            return Browser.GetDriver().FindElement(locator).Text;
        }

        public static bool IsElementVisible(By locator)
        {
            try
            {
                WaitElementIsVisible(locator);
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

        public static string GetAttributeValueFromElement(By locator, string attribute)
        {
            WaitElementIsVisible(locator);
            return Browser.GetDriver().FindElement(locator).GetAttribute(attribute);
        }

        public static void ClearField(By locator)
        {
            WaitElementIsVisible(locator);
            Browser.GetDriver().FindElement(locator).Clear();
        }

        public static IWebElement GetElement(By locator)
        {
            WaitElementIsVisible(locator);
            return Browser.GetDriver().FindElement(locator);
        }

        public static void ClickWithAction(By locator)
        {            
            var elementToClick = GetElement(locator);
            Browser.GetActions().MoveToElement(elementToClick).Click().Perform();
        }
    }
}
