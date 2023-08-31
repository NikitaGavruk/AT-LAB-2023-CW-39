using Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace AndroidUI.Driver
{
    public class DriverFactory
    {
        private static AndroidDriver<IWebElement> driver;
        private static DriverCapabilityModel capabilities = ExpectedDataReader.GetExpectedData<DriverCapabilityModel>(Core.enums.Resources.driverCapabilities);

        public static AndroidDriver<IWebElement> GetDriver()
        {
            if(driver == null)
            {
                InitDriver();
            }

            return driver;
        }

        private static void InitDriver()
        {
            Uri appiumUrl = new Uri("http://localhost:4723/wd/hub");
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("appium:automationName", capabilities.AutomationName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, capabilities.DeviceName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, capabilities.PlatformName); ;
            appiumOptions.AddAdditionalCapability("appium:appPackage", capabilities.Package);
            appiumOptions.AddAdditionalCapability("appium:appActivity", capabilities.Activity);

            //Disable the password save popup by allowing them
            appiumOptions.AddAdditionalCapability("autoGrantPermissions", capabilities.GrantPermissions);
            appiumOptions.AddAdditionalCapability("autoAcceptAlerts", capabilities.AcceptAlerts);

            driver = new AndroidDriver<IWebElement>(appiumUrl, appiumOptions);            
        }

        public static void ExitDriver()
        {
            driver.CloseApp();
            driver = null;
        }
    }
}
