using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using static UI.WebDriver.WebDriverFactory;
using System;

namespace UI.WebDriver
{
	public class Browser
	{
		public static BrowserType _currentBrowser;			
		private static int ImplWait;
		private static IWebDriver currentInstance;
		private static Actions _actions;
		private static IJavaScriptExecutor _jsExecuter;
		private static IWebDriver webDriver => GetDriver();

		private static void InitParams()
		{
			ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
			string browserFromConfig = Configuration.Browser;
			Enum.TryParse(browserFromConfig, out _currentBrowser);
		}

		private Browser()
		{
			InitParams();
			currentInstance = WebDriverFactory.GetDriver(_currentBrowser);
		}

		public static IWebDriver GetDriver()
		{
			if (currentInstance == null)
			{
				new Browser();
			}

			return currentInstance;
		}

		public static void WindowMaximize()
		{
			webDriver.Manage().Window.Maximize();
		}

		public static void NavigateTo(string url)
		{
			webDriver.Navigate().GoToUrl(url);
		}

		public static void StartNavigate()
		{
			webDriver.Navigate().GoToUrl(Configuration.StartUrl);
		}

		public static void QuitBrowser()
		{
			webDriver.Quit();			
			currentInstance = null;			
		}

		public static Actions GetActions()
		{
			_actions = new Actions(GetDriver());
			return _actions;
		}

		public static IJavaScriptExecutor GetJSExecuter()
		{
			_jsExecuter = (IJavaScriptExecutor)GetDriver();
			return _jsExecuter;
		}
	}
}
