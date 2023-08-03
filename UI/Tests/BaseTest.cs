using NUnit.Framework;
using UI.WebDriver;
using OpenQA.Selenium;
using Core.Utils;
using NUnit.Framework.Interfaces;
using Core.Interfaces;
using UI.Pages;
using LogLevel = Core.enums.LogLevel;


namespace UI.Tests
{
	public class BaseTest
	{
		protected static IWebDriver Driver;
		protected static ICustomLogger CustomLogger;

		[SetUp]
		public void Setup()
		{
			Driver = Browser.GetDriver();
			CustomLogger = new CustomLogger();
			CustomLogger.LogInfo(LogLevel.Info, $"Start Test [{TestContext.CurrentContext.Test.Name}]");
			Browser.WindowMaximize();
			Browser.StartNavigate();
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
			}
			else
			{
				var statusMessage = $"[{TestContext.CurrentContext.Test.Name}] Test ended with Status: " +
					TestContext.CurrentContext.Result.Outcome.Status.ToString();
				CustomLogger.LogInfo(LogLevel.Info, statusMessage);
			}
			Browser.QuitBrowser();
		}
	}
}
