using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System;
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

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
		}
	}
}
