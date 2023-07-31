using NUnit.Framework;
using UI.WebDriver;
using OpenQA.Selenium;

namespace UI.Tests
{
	public class BaseTest
	{
		protected static IWebDriver Driver;

		[SetUp]
		public void Setup()
		{
			Driver = Browser.GetDriver();
			Browser.WindowMaximaze();
			Browser.StartNavigate();
		}

		[TearDown]
		public void Quite()
		{
			Browser.QuiteBrowser();
		}
	}
}
