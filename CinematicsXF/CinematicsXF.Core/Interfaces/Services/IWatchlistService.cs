using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public interface IWatchlistService
    {
        Task<bool> AddAsync(MovieItem item);
        Task<IEnumerable<MediaItem>> GetAsync();
        Task<bool> RemoveAsync(MovieItem item);

        event EventHandler<MediaItem> WatchlistChanged;
    }
}
