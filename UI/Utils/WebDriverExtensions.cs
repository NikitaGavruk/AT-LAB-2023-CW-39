using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UI.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Utils
{
    public static class WebDriverExtensions
    {    
        public static void ClickOnElement(By locator, int waitSeconds)
        {
            IWebDriver driver = Browser.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
            wait.Until(d => d.FindElement(locator).Displayed);
            driver.FindElement(locator).Click();
        }

        public static void ClickOnElement(By locator)
        {
            IWebDriver driver = Browser.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(locator).Displayed);
            driver.FindElement(locator).Click();
        }

        public static void ClickOnEnter(By locator)
        {
            IWebDriver driver = Browser.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(locator).Displayed);
            driver.FindElement(locator).SendKeys(Keys.Enter);
        }

        public static string GetTextFromElement(By locator, int waitSeconds)
        {
            IWebDriver driver = Browser.GetDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));

        }
    }
}
