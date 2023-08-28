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
            //DriverExtensions.LauncApp();
            //driver = DriverFactory.GetDriver();
        }

        [Test]
        public void SimpleTest()
        {
            DriverExtensions.PressBack();
            DriverExtensions.ClickToElement(By.CssSelector("android.widget.TextView"));
            DriverExtensions.SendKeys(By.CssSelector("android.widget.EditText"), "Mikhail Lomonosov");
            //driver.PressKeyCode(AndroidKeyCode.Keycode_ENTER);
            //driver.FindElementByXPath("//*[@resource-id='org.wikipedia:id/page_list_item_title'][1]").Click();
            var heads = driver.FindElementByCssSelector(".android.widget.TextView").Text;


            Assert.That(heads, Is.EqualTo("Mikhail Lomonosov"));
        }

        [TearDown]
        public void Quit()
        {
            DriverFactory.ExitDriver();
        }

        [Test]
        public void Test2()
        {
            DriverExtensions.PressBack();
        }
    }
}
