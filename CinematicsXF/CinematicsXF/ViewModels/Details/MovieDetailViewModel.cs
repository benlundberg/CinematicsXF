using CinematicsXF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class MovieDetailViewModel : BaseViewModel
    {
        public MovieDetailViewModel(MovieItem movieItem)
        {
            movieService = ComponentContainer.Current.Resolve<IMovieService>();
            personService = ComponentContainer.Current.Resolve<IPersonService>();
            watchlistService = ComponentContainer.Current.Resolve<IWatchlistService>();

            this.Movie = movieItem;
        }

        public override void Appearing()
        {
            base.Appearing();

            LoadCastAndCrew();
            LoadSimilarMovies();
        }

        private ICommand personItemCommand;
        public ICommand PersonItemCommand => personItemCommand ?? (personItemCommand = new Command(async (param) =>
        {
            if (!(param is PersonItem personItem))
            {
                return;
            }

            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                var person = await personService.GetPersonDetailAsync(personItem.Id);

                if (person != null)
                {
                    await Navigation.PushAsync(ViewContainer.Current.CreatePage(new PersonDetailViewModel(person)));
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
        }));

        private ICommand movieItemCommand;
        public ICommand MovieItemCommand => movieItemCommand ?? (movieItemCommand = new Command(async (param) =>
        {
            if (!(param is MovieItem movieItem))
            {
                return;
            }

            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                var movie = await movieService.GetMovieDetailAsync(movieItem.Id);

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
        }));

        private ICommand favouriteCommand;
        public ICommand FavouriteCommand => favouriteCommand ?? (favouriteCommand = new Command(async () =>
        {
            Movie.IsFavourite = !Movie.IsFavourite;

            if (Movie.IsFavourite)
            {
                await watchlistService.AddAsync(Movie);
            }
            else
            {
                await watchlistService.RemoveAsync(Movie);
            }
        }));
        
        private void LoadCastAndCrew()
        {
            Task.Run(async () =>
            {
                try
                {
                    var persons = await movieService.GetMovieCreditsAsync(Movie.Id);

                    Persons = persons?.Cast != null ? new ObservableCollection<PersonItem>(persons.Cast) : new ObservableCollection<PersonItem>();
                }
                catch (Exception ex)
                {
                    ex.Print();
                }
            });
        }

        private void LoadSimilarMovies()
        {
            Task.Run(async () =>
            {
                try
                {
                    var movies = await movieService.GetSimiliarMoviesAsync(Movie.Id);

                    SimilarMovies = movies != null ? new ObservableCollection<MovieItem>(movies) : new ObservableCollection<MovieItem>();
                }
                catch (Exception ex)
                {
                    ex.Print();
                }
            });
        }

        public ObservableCollection<MovieItem> SimilarMovies { get; private set; }
        public ObservableCollection<PersonItem> Persons { get; private set; }
        public MovieItem Movie { get; private set; }

        private readonly IMovieService movieService;
        private readonly IPersonService personService;
        private readonly IWatchlistService watchlistService;
    }
}
