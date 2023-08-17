using UI.Pages;

namespace UI.Steps
{
    public static class ArticlePageSteps
    {
        private static ArticlePage _articlePage = new ArticlePage();

        public static WatchlistPage AddToWatchlist()
        {
            _articlePage.AddToWatchlist()
                .NavigateToWatchlist();
            
            return new WatchlistPage();
        }
    }
}
