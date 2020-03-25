using CinematicsXF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class SearchViewModel : BaseViewModel
    {
        public SearchViewModel()
        {
            movieService = ComponentContainer.Current.Resolve<IMovieService>();
            searchService = ComponentContainer.Current.Resolve<ISearchService>();
            personService = ComponentContainer.Current.Resolve<IPersonService>();
        }

        private ICommand searchCommand;
        public ICommand SearchCommand => searchCommand ?? (searchCommand = new Command(async () =>
        {
            if (IsBusy)
            {
                return;
            }

            if (string.IsNullOrEmpty(Query))
            {
                return;
            }

            try
            {
                IsBusy = true;

                var res = await searchService.SearchAsync(Query);

                if (res != null)
                {
                    if (res.Movies?.Any() == true)
                    {
                        movies = res.Movies;

                        if (res.Movies.Count() > 9)
                        {
                            Movies = new ObservableCollection<MovieItem>(res.Movies.Take(9));
                            HasMoreMovies = true;
                        }
                        else
                        {
                            Movies = new ObservableCollection<MovieItem>(res.Movies);
                            HasMoreMovies = false;
                        }
                    }

                    Persons = res.Persons?.Any() == true ? new ObservableCollection<PersonItem>(res.Persons) : new ObservableCollection<PersonItem>();
                }
                else
                {
                    // Notify user that no search result was found
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

        private ICommand movieClickCommand;
        public ICommand MovieClickCommand => movieClickCommand ?? (movieClickCommand = new Command(async (param) =>
        {
            if (!(param is MovieItem movie))
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

                var movieDetail = await movieService.GetMovieDetailAsync(movie.Id);

                if (movieDetail == null)
                {
                    return;
                }

                await Navigation.PushAsync(ViewContainer.Current.CreatePage(new MovieDetailViewModel(movieDetail)));
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

        private ICommand moreMoviesClickCommand;
        public ICommand MoreMoviesClickCommand => moreMoviesClickCommand ?? (moreMoviesClickCommand = new Command(async (param) =>
        {
            await Navigation.PushAsync(ViewContainer.Current.CreatePage(new ListViewModel(movies, Query)));
        }));

        private ICommand personClickCommand;
        public ICommand PersonClickCommand => personClickCommand ?? (personClickCommand = new Command(async (param) =>
        {
            if (!(param is PersonItem person))
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

                var personDetails = await personService.GetPersonDetailAsync(person.Id);

                if (personDetails == null)
                {
                    return;
                }

                await Navigation.PushAsync(ViewContainer.Current.CreatePage(new PersonDetailViewModel(personDetails)));
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

        public string Query { get; set; }
        public bool HasMoreMovies { get; set; }
        public ObservableCollection<MovieItem> Movies { get; private set; }
        public ObservableCollection<PersonItem> Persons { get; private set; }

        private IEnumerable<MovieItem> movies;

        private readonly ISearchService searchService;
        private readonly IMovieService movieService;
        private readonly IPersonService personService;
    }
}
