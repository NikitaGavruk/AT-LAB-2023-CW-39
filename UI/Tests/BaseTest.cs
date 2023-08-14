using Core.enums;
using Core.Model;
using NUnit.Framework;
using UI.WebDriver;
using OpenQA.Selenium;
using Core.Utils;
using NUnit.Framework.Interfaces;
using Core.Interfaces;
using UI.Pages;
using LogLevel = Core.enums.LogLevel;
using UI.Utils;

namespace UI.Tests
{
	public abstract class BaseTest
	{
		protected static IWebDriver Driver;
		protected static ICustomLogger CustomLogger;
		protected static Screenshoter Screenshoter;
		protected static MainPage MainPage;
		protected static AboutPage AboutPage;
		protected static ExpectedDataModel ExpectedData;

		[SetUp]
		public void Setup()
		{
			Driver = Browser.GetDriver();
			CustomLogger = new CustomLogger();
			Screenshoter = new Screenshoter();
			CustomLogger.LogInfo(LogLevel.Info, $"Start Test [{TestContext.CurrentContext.Test.Name}]");
			Browser.WindowMaximize();
			Browser.StartNavigate();

			// Initializing pages
			MainPage = new MainPage();
			AboutPage = new AboutPage();

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
                CustomLogger.LogInfo(LogLevel.Error, failMessage);
                Screenshoter.Capture();
            }
			else
			{
				var statusMessage = $"[{TestContext.CurrentContext.Test.Name}] Test ended with Status: " +
					TestContext.CurrentContext.Result.Outcome.Status;
				CustomLogger.LogInfo(LogLevel.Info, statusMessage);
			}
			Browser.QuitBrowser();
		}
	}
}
