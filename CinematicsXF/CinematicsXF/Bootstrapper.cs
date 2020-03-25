using CinematicsXF.Core;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class Bootstrapper
    {
        public static void RegisterTypes()
        {
            // Services
            ComponentContainer.Current.Register<ITranslateService, TranslateService>();
            ComponentContainer.Current.Register<ILoggerService, LoggerService>(singelton: true);

            ComponentContainer.Current.Register<IMovieService, MovieService>();
            ComponentContainer.Current.Register<IPersonService, PersonService>();
            ComponentContainer.Current.Register<ISearchService, SearchService>();
            ComponentContainer.Current.Register<IWatchlistService, WatchlistService>(singelton: true);
            ComponentContainer.Current.Register<ITvService, TvService>();
        }

        public static void RegisterViews()
        {
            ViewContainer.Current.Register<HomeMasterViewModel, HomeMasterPage>();
            ViewContainer.Current.Register<MasterViewModel, MasterPage>();
            ViewContainer.Current.Register<HomeTabbedViewModel, HomeTabbedPage>();
            ViewContainer.Current.Register<LoggerViewModel, LoggerPage>();
            ViewContainer.Current.Register<SearchViewModel, SearchPage>();
            ViewContainer.Current.Register<WatchlistViewModel, WatchlistPage>();
            ViewContainer.Current.Register<MovieDetailViewModel, MovieDetailPage>();
            ViewContainer.Current.Register<TvViewModel, TvPage>();
            ViewContainer.Current.Register<PersonDetailViewModel, PersonDetailPage>();
            ViewContainer.Current.Register<ListViewModel, ListPage>();
            ViewContainer.Current.Register<TvDetailViewModel, TvDetailPage>();

            if (Device.Idiom == TargetIdiom.Phone)
            {
                ViewContainer.Current.Register<MoviesViewModel, Views.Movies.Phone.MoviesPage>();
            }
            else
            {
                // Register desktop/tablet
            }
        }

        public static void CreateTables()
        {
            DatabaseRepository.Current.CreateTablesAsync(new List<Type>()
            {
                typeof(MediaItem),
                typeof(MovieItem),
                typeof(TvItem)
            }).ConfigureAwait(false);
        }
    }
}
