using CinematicsXF.Core.Dto.Tv;
using CinematicsXF.Core.Dto.TvDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public class TvService : BaseService, ITvService
    {
        public async Task<IEnumerable<TvItem>> GetOnAirTvAsync(int page = 1)
        {
            try
            {
                // First check the memory cache
                var local = await MemoryRepository.Current.LoadAsync<IList<TvItem>>(MemoryKey.TvOnAir + page);

                if (local?.Any() == true)
                {
                    return local;
                }

                // Make request
                var res = await MakeRequestAsync<TvResultDto>(string.Format(ServiceConfig.GetOnAirTv, page), HttpMethod.Get);

                // Create movie list
                var tvs = res?.Results?.Select(tv => tv.ToTvItem());

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.TvOnAir + page, tvs);

                return tvs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TvItem>> GetPopularTvAsync(int page = 1)
        {
            try
            {
                // First check the memory cache
                var local = await MemoryRepository.Current.LoadAsync<IList<TvItem>>(MemoryKey.TvDiscover + page);

                if (local?.Any() == true)
                {
                    return local;
                }

                // Make request
                var res = await MakeRequestAsync<TvResultDto>(string.Format(ServiceConfig.GetPopularTv, page), HttpMethod.Get);

                // Create movie list
                var tvs = res?.Results?.Select(tv => tv.ToTvItem());

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.TvDiscover + page, tvs);

                return tvs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TvItem>> GetTopRatedTvAsync(int page = 1)
        {
            try
            {
                // First check the memory cache
                var local = await MemoryRepository.Current.LoadAsync<IList<TvItem>>(MemoryKey.TvTopRated + page);

                if (local?.Any() == true)
                {
                    return local;
                }

                // Make request
                var res = await MakeRequestAsync<TvResultDto>(string.Format(ServiceConfig.GetTopRatedTv, page), HttpMethod.Get);

                // Create movie list
                var tvs = res?.Results?.Select(tv => tv.ToTvItem());

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.TvTopRated + page, tvs);

                return tvs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TvItem> GetTvDetailsAsync(int id)
        {
            try
            {
                // First check the memory cache
                var tvItem = await MemoryRepository.Current.LoadAsync<TvItem>(MemoryKey.TvDetails + id);

                if (tvItem != null)
                {
                    // Check if favourite
                    tvItem.IsFavourite = await DatabaseRepository.Current.LoadAsync<TvItem>(id) != null;

                    return tvItem;
                }

                // Make request
                var res = await MakeRequestAsync<TvDetailDto>(string.Format(ServiceConfig.GetTvDetail, id), HttpMethod.Get);

                tvItem = res.ToTvItem();

                // Save to memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.TvDetails + id, tvItem);

                // Check if favourite
                tvItem.IsFavourite = tvItem.IsFavourite = await DatabaseRepository.Current.LoadAsync<TvItem>(id) != null;

                return tvItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
