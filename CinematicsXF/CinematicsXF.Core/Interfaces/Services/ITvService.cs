using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public interface ITvService
    {
        Task<IEnumerable<TvItem>> GetPopularTvAsync(int page = 1);
        Task<IEnumerable<TvItem>> GetTopRatedTvAsync(int page = 1);
        Task<IEnumerable<TvItem>> GetOnAirTvAsync(int page = 1);
        Task<TvItem> GetTvDetailsAsync(int id);
    }
}
