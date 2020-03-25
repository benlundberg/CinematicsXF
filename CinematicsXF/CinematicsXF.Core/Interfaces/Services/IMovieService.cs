using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieItem>> GetTopRatedMoviesAsync(int page = 1);
        Task<IEnumerable<MovieItem>> GetDiscoverMoviesAsync(int page = 1);
        Task<IEnumerable<MovieItem>> GetUpcomingMoviesAsync(int page = 1);
        Task<IEnumerable<MovieItem>> GetNowPlayingMoviesAsync(int page = 1);
        Task<IEnumerable<MovieItem>> GetSimiliarMoviesAsync(int id);
        Task<MovieItem> GetMovieDetailAsync(int id);
        Task<CreditsResult> GetMovieCreditsAsync(int movieId);
    }
}
