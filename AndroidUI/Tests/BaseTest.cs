using AndroidUI.Driver;
using AndroidUI.Pages;
using AndroidUI.Utils;
using Core.enums;
using Core.Interfaces;
using Core.Model;
using Core.Utils;
using NUnit.Framework.Interfaces;

namespace AndroidUI.Tests
{
    public abstract class BaseTest
    {
        protected ICustomLogger Logger;
        protected MainPage mainPage = new MainPage();
        protected EnglishLanguagePage languagePage = new EnglishLanguagePage();
        protected ExpectedDataModel ExpectedData;

        [SetUp]
        public void Setup()
        {
            Logger = new CustomLogger();
            Logger.LogInfo(LogLevel.Info, $"Start Test [{TestContext.CurrentContext.Test.Name}]");
            ExpectedData = ExpectedDataReader.GetExpectedData<ExpectedDataModel>(Resources.ExpectedData);
        }

        [TearDown]
        public void Quit()
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

            DriverFactory.ExitDriver();
        }
    }
}