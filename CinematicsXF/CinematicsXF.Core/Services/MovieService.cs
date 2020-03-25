using CinematicsXF.Core.Dto.Movie;
using CinematicsXF.Core.Dto.MovieDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public class MovieService : BaseService, IMovieService
    {
        public async Task<IEnumerable<MovieItem>> GetDiscoverMoviesAsync(int page = 1)
        {
            try
            {
                // First check the memory cache
                var local = await MemoryRepository.Current.LoadAsync<IList<MovieItem>>(MemoryKey.Discover + page);

                if (local?.Any() == true)
                {
                    return local;
                }

                // Make request
                var response = await MakeRequestAsync(string.Format(ServiceConfig.GetDiscoverMovies, page), HttpMethod.Get);

                response.EnsureSuccess();
                
                var res = MovieResultDto.FromJson(response.Data.ToString());

                // Create movie list
                var movies = res?.Results?.Select(movie => movie.ToMovieItem());

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.Discover + page, movies);

                return movies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MovieItem> GetMovieDetailAsync(int id)
        {
            try
            {
                // First check the memory cache
                var movie = await MemoryRepository.Current.LoadAsync<MovieItem>(MemoryKey.MovieDetail + id);

                if (movie != null)
                {
                    // Check if favourite
                    movie.IsFavourite = await DatabaseRepository.Current.LoadAsync<MovieItem>(id) != null;

                    return movie;
                }

                // Make request
                var res = await MakeRequestAsync(string.Format(ServiceConfig.GetMovieDetail, id), HttpMethod.Get);

                res.EnsureSuccess();

                movie = MovieDetailResultDto.FromJson(res.Data.ToString()).ToMovieItem();

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.MovieDetail + id, movie);

                // Check if favourite
                movie.IsFavourite = movie.IsFavourite = await DatabaseRepository.Current.LoadAsync<MovieItem>(id) != null;

                return movie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MovieItem>> GetNowPlayingMoviesAsync(int page = 1)
        {
            try
            {
                // First check the memory cache
                var local = await MemoryRepository.Current.LoadAsync<IList<MovieItem>>(MemoryKey.NowPlaying + page);

                if (local?.Any() == true)
                {
                    return local;
                }

                // Make request
                var response = await MakeRequestAsync(string.Format(ServiceConfig.GetNowPlayingMovies, page), HttpMethod.Get);

                response.EnsureSuccess();

                var res = MovieResultDto.FromJson(response.Data.ToString());

                // Create movie list
                var movies = res?.Results?.Select(movie => movie.ToMovieItem());

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.NowPlaying + page, movies);

                return movies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MovieItem>> GetSimiliarMoviesAsync(int id)
        {
            try
            {
                // First check the memory cache
                var local = await MemoryRepository.Current.LoadAsync<IList<MovieItem>>(MemoryKey.Similar + id);

                if (local?.Any() == true)
                {
                    return local;
                }

                // Make request
                var response = await MakeRequestAsync(string.Format(ServiceConfig.GetSimilarMovies, id), HttpMethod.Get);

                response.EnsureSuccess();

                var res = MovieResultDto.FromJson(response.Data.ToString());

                // Create movie list
                var movies = res?.Results?.Select(movie => movie.ToMovieItem());

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.Similar + id, movies);

                return movies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MovieItem>> GetTopRatedMoviesAsync(int page = 1)
        {
            try
            {
                // First check the memory cache
                var local = await MemoryRepository.Current.LoadAsync<IList<MovieItem>>(MemoryKey.TopRated + page);

                if (local?.Any() == true)
                {
                    return local;
                }

                // Make request
                var response = await MakeRequestAsync(string.Format(ServiceConfig.GetTopRatedMovies, page), HttpMethod.Get);

                response.EnsureSuccess();

                var res = MovieResultDto.FromJson(response.Data.ToString());

                // Create movie list
                var movies = res?.Results?.Select(movie => movie.ToMovieItem());

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.TopRated + page, movies);

                return movies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MovieItem>> GetUpcomingMoviesAsync(int page = 1)
        {
            try
            {
                // First check the memory cache
                var local = await MemoryRepository.Current.LoadAsync<IList<MovieItem>>(MemoryKey.UpComing + page);

                if (local?.Any() == true)
                {
                    return local;
                }

                // Make request
                var response = await MakeRequestAsync(string.Format(ServiceConfig.GetUpcomingMovies, page), HttpMethod.Get);

                response.EnsureSuccess();

                var res = MovieResultDto.FromJson(response.Data.ToString());

                // Create movie list
                var movies = res?.Results?.Select(movie => movie.ToMovieItem());

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.UpComing + page, movies);

                return movies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CreditsResult> GetMovieCreditsAsync(int movieId)
        {
            try
            {
                // Check memory cache first
                var movieCredits = await MemoryRepository.Current.LoadAsync<CreditsResult>(MemoryKey.MovieCredits + movieId);

                if (movieCredits != null)
                {
                    return movieCredits;
                }

                // Make request
                var response = await MakeRequestAsync(string.Format(ServiceConfig.GetMovieCredits, movieId), HttpMethod.Get);

                response.EnsureSuccess();

                var res = Dto.MovieCredits.MovieCreditsResultDto.FromJson(response.Data.ToString());

                // Create credits
                movieCredits = new CreditsResult
                {
                    Id = movieId,
                    Cast = res.Cast?.Select(cast => cast.ToPersonItem()),
                    Crew = res.Crew?.Select(crew => crew.ToPersonItem())
                };

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.MovieCredits + movieId, movieCredits);

                return movieCredits;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
