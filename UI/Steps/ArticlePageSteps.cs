using UI.Pages;

namespace UI.Steps
{
	public class ArticlePageSteps
	{
		private static ArticlePage articlePage = new ArticlePage();

		public static WatchlistPage AddToWatchlist()
		{
			articlePage.AddToWatchlist()
				.ToWatchlist();
			return new WatchlistPage();
		}
	}
}
