using OpenQA.Selenium;
using System.Web.UI.WebControls;
using UI.Utils;

namespace UI.Pages
{
	public class WatchlistPage : AbstractPage
	{
		private static readonly By viewWatchlistTab = By.XPath("(//a[@href='/wiki/Special:EditWatchlist'])[1]");

		public WatchlistPage ToViewWachlistTab()
		{
			WebDriverExtension.ClickOnElement(viewWatchlistTab);
			return new WatchlistPage();
		}

		public bool IsArticleOnList(string articleTitle)
		{
			By article = By.XPath($"//a[@title='{articleTitle}']");
			return WebDriverExtension.IsElementVisible(article);
		}
	}
}