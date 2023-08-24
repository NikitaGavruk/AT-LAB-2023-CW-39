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
        private static DriverCapabilityModel capabilitys = ExpectedDataReader.GetExpectedData<DriverCapabilityModel>(Core.enums.Resources.DriverCapabilitys);

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
            appiumOptions.AddAdditionalCapability("appium:automationName", capabilitys.AutomationName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, capabilitys.DeviceName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, capabilitys.PlatformName); ;
            appiumOptions.AddAdditionalCapability("appium:appPackage", capabilitys.Package);
            appiumOptions.AddAdditionalCapability("appium:appActivity", capabilitys.Activity);

            driver = new AndroidDriver<IWebElement>(appiumUrl, appiumOptions);            
        }

        public void ExitDriver()
        {
            driver.CloseApp();
            driver = null;
        }
    }
}
