using CinematicsXF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class ListViewModel : BaseViewModel
    {
        public ListViewModel(IEnumerable<MovieItem> movies, string title = AppConfig.AppName)
        {
            movieService = ComponentContainer.Current.Resolve<IMovieService>();

            this.Title = title;
            this.MovieItems = movies != null ? new ObservableCollection<MovieItem>(movies) : new ObservableCollection<MovieItem>();
        }

        private void MovieSelected(int id)
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

                    var movieDetail = await movieService.GetMovieDetailAsync(id);

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
            });
        }

        private ICommand movieClickCommand;
        public ICommand MovieClickCommand => movieClickCommand ?? (movieClickCommand = new Command((param) =>
        {
            if (!(param is MovieItem movie))
            {
                return;
            }

            MovieSelected(movie.Id);
        }));

        private ICommand changeLayoutClickCommand;
        public ICommand ChangeLayoutClickCommand => changeLayoutClickCommand ?? (changeLayoutClickCommand = new Command(() =>
        {
            IsListLayout = !IsListLayout;
        }));

        private MovieItem selectedMovie;
        public MovieItem SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;

                if (selectedMovie != null)
                {
                    MovieSelected(selectedMovie.Id);

                    SelectedMovie = null;
                }
            }
        }

        public ObservableCollection<MovieItem> MovieItems { get; protected set; }
        public bool IsListLayout { get; set; }
        public string Title { get; set; }

        protected readonly IMovieService movieService;
    }
}
