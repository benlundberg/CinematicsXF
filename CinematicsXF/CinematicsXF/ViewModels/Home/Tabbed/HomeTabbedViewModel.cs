using Xamarin.Forms;

namespace CinematicsXF
{
    public class HomeTabbedViewModel : BaseViewModel
    {
        public override void OnPageCreated(Page page)
        {
            if (!(page is TabbedPage homePage))
            {
                return;
            }

            // Adding pages to the tabbed page //

            var moviesPage = ViewContainer.Current.CreatePage<MoviesViewModel>();
            moviesPage.Title = Translate("Gen_Movies");
            homePage.Children.Add(moviesPage);

            var tvPage = ViewContainer.Current.CreatePage<TvViewModel>();
            tvPage.Title = Translate("Gen_Tv");
            homePage.Children.Add(tvPage);

            var searchPage = ViewContainer.Current.CreatePage<SearchViewModel>();
            searchPage.Title = Translate("Gen_Search");
            homePage.Children.Add(searchPage);

            var watchlistPage = ViewContainer.Current.CreatePage<WatchlistViewModel>();
            watchlistPage.Title = Translate("Gen_Watchlist");
            homePage.Children.Add(watchlistPage);

            base.OnPageCreated(page);
        }
    }
}
