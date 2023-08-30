using Mobile.Driver;
using OpenQA.Selenium.Appium.Android.UiAutomator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Test
{
    [TestFixture]
    public class Test
    {
        private Swiper swiper = new(DriverFactory.GetDriver());

        [Test]
        public void Test1()
        {
            var driver = DriverFactory.GetDriver();
            driver.Navigate().Back();

            //swiper.Swipe(Swiper.SwipeDirection.SWIPE_DOWN);
            //swiper.Swipe(Swiper.SwipeDirection.SWIPE_UP); //about 25 sec per action
            //swiper.SimpleSwipe();
            //driver.FindElementByAndroidUIAutomator("new UiScrollable().scrollForward()").Click();

            //var asd = new AndroidUiSelector().IsScrollable(true).Instance(0);
            var scrl = new AndroidUiScrollable().ScrollBackward();
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollForward()");
            driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollBackward()");

        }

    }
}
