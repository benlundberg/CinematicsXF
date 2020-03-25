using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public class WatchlistService : IWatchlistService
    {
        public async Task<bool> AddAsync(MovieItem item)
        {
            try
            {
                await DatabaseRepository.Current.InsertAsync(item);

                WatchlistChanged?.Invoke(this, item);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MediaItem>> GetAsync()
        {
            List<MediaItem> items = new List<MediaItem>();

            var movies = await DatabaseRepository.Current.LoadAllAsync<MovieItem>();

            // TODO: Load tv items

            if (movies != null)
            {
                items.AddRange(movies);
            }

            return items;
        }

        public async Task<bool> RemoveAsync(MovieItem item)
        {
            try
            {
                await DatabaseRepository.Current.DeleteAsync(entity: item);

                WatchlistChanged?.Invoke(this, item);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public event EventHandler<MediaItem> WatchlistChanged;
    }
}
