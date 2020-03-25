namespace CinematicsXF.Core
{
    /// <summary>
    /// Static helper methods to map objects
    /// </summary>
    public static class Mapper
    {
        #region MovieItem

        internal static MovieItem ToMovieItem(this Dto.PersonsCredits.Cast movie)
        {
            return new MovieItem
            {
                BackdropPath = movie.BackdropPath,
                Id = movie.Id ?? 0,
                Overview = movie.Overview,
                Title = movie.Title,
                VoteAverage = movie.VoteAverage ?? 0,
                Popularity = movie.Popularity ?? 0,
                PosterPath = movie.PosterPath,
            };
        }

        internal static MovieItem ToMovieItem(this Dto.MovieDetail.MovieDetailResultDto movieDetail)
        {
            var movieItem = new MovieItem
            {
                BackdropPath = movieDetail.BackdropPath,
                Id = movieDetail.Id ?? 0,
                Overview = movieDetail.Overview,
                Title = movieDetail.Title,
                VoteAverage = movieDetail.VoteAverage ?? 0,
                Popularity = movieDetail.Popularity ?? 0,
                ReleaseDate = movieDetail.ReleaseDate,
                PosterPath = movieDetail.PosterPath,
                Runtime = movieDetail.Runtime + " min",
                Tagline = movieDetail.Tagline,
            };

            movieDetail.Genres.ForEach(genre => movieItem.Genres += genre.Name + " ");

            return movieItem;
        }

        internal static MovieItem ToMovieItem(this Dto.Movie.Result movie)
        {
            return new MovieItem
            {
                BackdropPath = movie.BackdropPath,
                Id = movie.Id ?? 0,
                Overview = movie.Overview,
                Title = movie.Title,
                VoteAverage = movie.VoteAverage ?? 0,
                Popularity = movie.Popularity ?? 0,
                ReleaseDate = movie.ReleaseDate,
                PosterPath = movie.PosterPath
            };
        }

        internal static MovieItem ToMovieItem(this Dto.Search.Result movie)
        {
            return new MovieItem
            {
                BackdropPath = movie.BackdropPath,
                Id = movie.Id ?? 0,
                Overview = movie.Overview,
                Popularity = movie.Popularity ?? 0,
                PosterPath = movie.PosterPath,
                VoteAverage = movie.VoteAverage ?? 0,
                Title = movie.Title
            };
        }

        #endregion

        #region PersonItem

        internal static PersonItem ToPersonItem(this Dto.MovieCredits.Cast cast)
        {
            return new PersonItem
            {
                Id = cast.Id ?? 0,
                Name = cast.Name,
                ProfilePath = cast.ProfilePath,
                Character = cast.Character
            };
        }

        internal static PersonItem ToPersonItem(this Dto.MovieCredits.Crew crew)
        {
            return new PersonItem
            {
                Id = crew.Id ?? 0,
                Name = crew.Name,
                ProfilePath = crew.ProfilePath,
                KnownForDepartment = crew.Department?.ToString(),
                Job = crew.Job,
            };
        }

        internal static PersonItem ToPersonItem(this Dto.PersonDetail.PersonDetailResultDto person)
        {
            var personItem = new PersonItem
            {
                Id = person.Id ?? 0,
                Name = person.Name,
                ProfilePath = person.ProfilePath,
                Biography = person.Biography,
                PlaceOfBirth = person.PlaceOfBirth,
                KnownForDepartment = person.KnownForDepartment,
                Birthday = person.Birthday,
            };

            person.AlsoKnownAs.ForEach(aka => personItem.AlsoKnownAs += aka + " ");

            return personItem;
        }

        internal static PersonItem ToPersonItem(this Dto.Search.Result person)
        {
            return new PersonItem
            {
                Id = person.Id ?? 0,
                Name = person.Name,
                ProfilePath = person.ProfilePath,
            };
        }

        #endregion

        #region TvItem

        internal static TvItem ToTvItem(this Dto.Tv.Result tv)
        {
            return new TvItem
            {
                Id = tv.Id ?? 0,
                Overview = tv.Overview,
                BackdropPath = tv.BackdropPath,
                Title = tv.Name,
                PosterPath = tv.PosterPath
            };
        }

        internal static TvItem ToTvItem(this Dto.TvDetail.TvDetailDto tv)
        {
            var tvItem = new TvItem
            {
                Id = tv.Id ?? 0,
                Overview = tv.Overview,
                BackdropPath = tv.BackdropPath,
                Title = tv.Name,
                PosterPath = tv.PosterPath,
                ReleaseDate = tv.FirstAirDate,
                VoteAverage = tv.VoteAverage ?? 0,
                NumberOfSeasons = tv.NumberOfSeasons ?? 0
            };

            tv.Genres.ForEach(genre => tvItem.Genres += genre.Name + " ");

            return tvItem;
        }

        #endregion
    }
}
