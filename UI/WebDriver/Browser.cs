using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using static UI.WebDriver.WebDriverFactory;
using System;

namespace UI.WebDriver
{
	public class Browser
	{
		private static BrowserType _currentBrowser;
		private static IWebDriver _currentInstance;
		private static IWebDriver webDriver => GetDriver();

		private static void InitParams()
		{
			Convert.ToInt32(Configuration.ElementTimeout);
			string browserFromConfig = Configuration.Browser;
			Enum.TryParse(browserFromConfig, out _currentBrowser);
		}

		private Browser()
		{
			InitParams();
			_currentInstance = WebDriverFactory.GetDriver(_currentBrowser);
		}

		public static IWebDriver GetDriver()
		{
			if (_currentInstance == null)
			{
				new Browser();
			}

			return _currentInstance;
		}

		public static void WindowMaximize() => webDriver.Manage().Window.Maximize();
		
		public static void NavigateTo(string url) => webDriver.Navigate().GoToUrl(url);
		
		public static void StartNavigate() => webDriver.Navigate().GoToUrl(Configuration.StartUrl);

		public static void QuitBrowser()
		{
			webDriver.Quit();			
			_currentInstance = null;			
		}

		public static Actions GetActions() => new Actions(GetDriver());
		
		public static IJavaScriptExecutor GetJSExecuter() => (IJavaScriptExecutor)GetDriver();
	}
}
