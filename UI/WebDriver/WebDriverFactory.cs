using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace UI.WebDriver
{
    public static class WebDriverFactory
    {
        public enum BrowserType
        {
            Chrome,
            Edge,
            RemoteChrome,            
            Firefox,            
        }

        public static IWebDriver GetDriver(BrowserType browser)
        {
            IWebDriver driver = null;
            Uri gridHubUrl = new Uri("http://localhost:8081/wd/hub");

            switch (browser)
            {
                case BrowserType.Edge:
                    driver = new EdgeDriver();
                    break;
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.RemoteChrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--headless", "--no-sandobx", "--disable-dev-shm-usage");
                    driver = new RemoteWebDriver(chromeOptions);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
            }

            return driver;
        }
    }
}