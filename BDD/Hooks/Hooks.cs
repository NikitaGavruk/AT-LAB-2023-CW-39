using Core.enums;
using Core.Utils;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UI.Utils;
using UI.WebDriver;
using LogLevel = Core.enums.LogLevel;
using API.APIUtils;

namespace BDD.Hooks
{
    [Binding]
    public class Hooks
    {
        protected IWebDriver Driver;
        protected CustomLogger Logger;
        protected Screenshoter Screenshoter;

        [BeforeScenario]
        public void Setup()
        {
            Screenshoter = new Screenshoter();
            Driver = Browser.GetDriver();
            Browser.WindowMaximize();
            Browser.StartNavigate();
            Logger = new CustomLogger();

            Logger.LogInfo(Core.enums.LogLevel.Info, $"Start testcase {TestContext.CurrentContext.Test.Name}");
        }

        [AfterScenario]
        public void TearDown()
        {
            TestStatus NUnit_status = TestContext.CurrentContext.Result.Outcome.Status;

            if (NUnit_status.Equals(TestStatus.Failed))
            {
                var failMessage = $"[{TestContext.CurrentContext.Test.Name}] Test failed with Status: " +
                    TestContext.CurrentContext.Result.Message;
                Logger.LogInfo(LogLevel.Error, failMessage);
                Screenshoter.Capture();
            }
            else
            {
                var statusMessage = $"[{TestContext.CurrentContext.Test.Name}] Test ended with Status: " +
                    TestContext.CurrentContext.Result.Outcome.Status;
                Logger.LogInfo(LogLevel.Info, statusMessage);
            }

            Browser.QuitBrowser();
            Driver = null;
        }
    }
}
