using CinematicsXF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class PersonDetailViewModel : BaseViewModel
    {
        public PersonDetailViewModel(PersonItem person)
        {
            movieService = ComponentContainer.Current.Resolve<IMovieService>();
            personService = ComponentContainer.Current.Resolve<IPersonService>();

            Person = person;
        }

        public override void Appearing()
        {
            base.Appearing();

            LoadSimilarMovies();
        }

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

        private void LoadSimilarMovies()
        {
            Task.Run(async () =>
            {
                try
                {
                    var movies = await personService.GetPersonsCreditsAsync(Person.Id);

                    Movies = movies?.Movies != null ? new ObservableCollection<MovieItem>(movies?.Movies) : new ObservableCollection<MovieItem>();
                }
                catch (Exception ex)
                {
                    ex.Print();
                }
            });
        }

        public ObservableCollection<MovieItem> Movies { get; private set; }
        public PersonItem Person { get; private set; }

        private readonly IMovieService movieService;
        private readonly IPersonService personService;
    }
}
