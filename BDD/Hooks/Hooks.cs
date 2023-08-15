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
    public class Hooks
    {
        protected IWebDriver Driver;
        protected CustomLogger Logger;
        protected Screenshoter Screenshoter;
        protected Client client;
        protected API.APIUtils.API api;

        [BeforeScenario]
        [Scope(Tag = "UI")]
        public void StartUpUI()
        {
            Screenshoter = new Screenshoter();
            Driver = Browser.GetDriver();
            Browser.WindowMaximize();
            Browser.StartNavigate();
        }

        [BeforeScenario]
        [Scope(Tag = "API")]
        public void StartUpAPI()
        {
            client = Client.Instance;
            api = new API.APIUtils.API();
        }

        [BeforeScenario]
        public void Setup()
        {
            Logger = new CustomLogger();
            Logger.LogInfo(Core.enums.LogLevel.Info, $"Start testcase {TestContext.CurrentContext.Test.Name}");
        }

        [AfterScenario]
        [Scope(Tag = "UI")]
        public void CloseBrowser()
        {
            TestStatus NUnit_status = TestContext.CurrentContext.Result.Outcome.Status;

            if (NUnit_status.Equals(TestStatus.Failed))
            {
                Screenshoter.Capture();
            }

            Browser.QuitBrowser();
            Driver = null;
        }

        [AfterScenario]
        [Scope(Tag = "API")]
        public void TearDownAPI()
        {
            API.APIUtils.API.CloseRequest();
            api = null;
            client = null;
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
            }
            else
            {
                var statusMessage = $"[{TestContext.CurrentContext.Test.Name}] Test ended with Status: " +
                    TestContext.CurrentContext.Result.Outcome.Status;
                Logger.LogInfo(LogLevel.Info, statusMessage);
            }
        }
    }
}
