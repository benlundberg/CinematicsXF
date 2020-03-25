using CinematicsXF.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class MoviesViewModel : BaseViewModel
    {
        public MoviesViewModel()
        {
            movieService = ComponentContainer.Current.Resolve<IMovieService>();
        }

        public override void Appearing()
        {
            base.Appearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await LoadMoviesAsync();
            });
        }
        
        private ICommand itemClickedCommand;
        public ICommand ItemClickedCommand => itemClickedCommand ?? (itemClickedCommand = new Command((param) =>
        {
            if (!(param is MovieItem item))
            {
                return;
            }

            ItemSelected(item.Id);
        }));

        private void ItemSelected(int id)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (IsBusy)
                {
                    return;
                }

                try
                {
                    IsBusy = true;

                    var movie = await movieService.GetMovieDetailAsync(id);

                    if (movie != null)
                    {
                        await Navigation.PushAsync(ViewContainer.Current.CreatePage(new MovieDetailViewModel(movie)));
                    }
                }
                catch (Exception ex)
                {
                    ex.Print();
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }

        private MovieItem selectedItem;
        public MovieItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;

                if (selectedItem != null)
                {
                    ItemSelected(selectedItem.Id);

                    SelectedItem = null;
                }
            }
        }
        
        private async Task LoadMoviesAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                var discoverMovies = await movieService.GetDiscoverMoviesAsync();
                DiscoverMoviesFirst = discoverMovies != null ? new ObservableCollection<MovieItem>(discoverMovies.Take(5)) : new ObservableCollection<MovieItem>();
                DiscoverMoviesLast = discoverMovies != null ? new ObservableCollection<MovieItem>(discoverMovies.Skip(5)) : new ObservableCollection<MovieItem>();

                var upcomingMovies = await movieService.GetUpcomingMoviesAsync();
                UpcomingMovies = upcomingMovies != null ? new ObservableCollection<MovieItem>(upcomingMovies) : new ObservableCollection<MovieItem>();
                
                var topratedMovies = await movieService.GetTopRatedMoviesAsync();
                TopRatedMovies = topratedMovies != null ? new ObservableCollection<MovieItem>(topratedMovies) : new ObservableCollection<MovieItem>(); 
                
                var nowPlayingMovies = await movieService.GetNowPlayingMoviesAsync();
                NowPlayingMovies = nowPlayingMovies != null ? new ObservableCollection<MovieItem>(nowPlayingMovies) : new ObservableCollection<MovieItem>();
            }
            catch (Exception ex)
            {
                ex.Print();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ObservableCollection<MovieItem> DiscoverMoviesFirst { get; set; }
        public ObservableCollection<MovieItem> DiscoverMoviesLast { get; set; }
        public ObservableCollection<MovieItem> TopRatedMovies { get; set; }
        public ObservableCollection<MovieItem> UpcomingMovies { get; set; }
        public ObservableCollection<MovieItem> NowPlayingMovies { get; set; }

        private readonly IMovieService movieService;
    }
}
