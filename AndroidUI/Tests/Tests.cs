using AndroidUI.Driver;
using AndroidUI.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUI.Tests
{
    [TestFixture]
    public class Tests
    {
        private AndroidDriver<IWebElement> driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.GetDriver();
        }

        [Test]
        public void SimpleTest()
        {
            DriverExtensions.PressBack();
            DriverExtensions.ClickToElement(By.CssSelector("android.widget.TextView"));
            DriverExtensions.SendKeys(By.CssSelector("android.widget.EditText"), "Mikhail Lomonosov");
            driver.PressKeyCode(AndroidKeyCode.Keycode_ENTER);

            Assert.Pass();
        }
    }
}
