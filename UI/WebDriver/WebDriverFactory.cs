using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WebDriver
{
    public class WebDriverFactory
    {
        private static IWebDriver driver;
        public enum BrowserType
        {
            Chrome,
            Edge,
            RemoteChrome,
            RemoteEdge,
            Firefox,
            RemoteFirefox
        }        

        public static IWebDriver GetInstance(BrowserType browser)
        {
            if (driver == null)
            {
                driver = CreateDriver(browser);
                driver.Manage().Window.Maximize();                
            }

            return driver;
        }

        private static IWebDriver CreateDriver(BrowserType browser)
        {            
            switch (browser)
            {
                case BrowserType.Edge:
                    driver = new EdgeDriver();                    
                    break;
                case BrowserType.RemoteChrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--headless", "--lang= en-US", "--accept-lang=en-US");                                       
                    driver = new ChromeDriver();
                    break;
                case BrowserType.RemoteEdge:
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments("--headless");
                    driver = new EdgeDriver(edgeOptions);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.RemoteFirefox:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments("--headless");
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}