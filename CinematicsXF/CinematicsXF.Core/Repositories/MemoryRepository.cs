using Akavache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public class MemoryKey
    {
        internal const string Discover = "Discover";
        internal const string TopRated = "TopRated";
        internal const string NowPlaying = "NowPlaying";
        internal const string MovieDetail = "MovieDetail";
        internal const string Similar = "Similar";
        internal const string UpComing = "UpComing";
        internal const string MovieCredits = "MovieCredits";
        internal const string PersonDetail = "PersonDetail";
        internal const string PersonsCredits = "PersonsCredits";
        internal const string TvDiscover = "TvDiscover";
        internal const string TvOnAir = "TvOnAir";
        internal const string TvTopRated = "TvTopRated";
        internal const string TvDetails = "TvDetails";
    }

    public class MemoryRepository : IRepository
    {
        static Lazy<IRepository> implementation;

        public static IRepository Current
        {
            get
            {
                var ret = implementation?.Value;

                if (ret == null)
                {
                    implementation = new Lazy<IRepository>(() => Create(), isThreadSafe: true);
                    ret = implementation.Value;
                }

                return ret;
            }
        }

        private static IRepository Create()
        {
            BlobCache.ApplicationName = AppConfig.AppName;
            return new MemoryRepository();
        }

        public void Init(IRepository repository)
        {
            implementation = new Lazy<IRepository>(() => repository, isThreadSafe: true);
        }

        public async Task SaveAsync<T>(string id, T model)
        {
            try
            {
                await BlobCache.InMemory.InsertObject(id + model.GetType().ToString(), model);
            }
            catch (Exception ex)
            {
                ex.Print();
            }
        }

        public async Task<T> LoadAsync<T>(string id)
        {
            try
            {
                return await BlobCache.InMemory.GetObject<T>(id + typeof(T).ToString());
            }
            catch (Exception ex)
            {
                ex.Print();
            }

            return default;
        }

        public async Task<T> LoadAsync<T>(Func<T, bool> predExpr)
        {
            try
            {
                var list = await GetAllAsync<T>();

                return list.FirstOrDefault(predExpr);
            }
            catch (Exception ex)
            {
                ex.Print();
            }

            return default;
        }

        public async Task DeleteAsync<T>(string id)
        {
            try
            {
                await BlobCache.InMemory.InvalidateObject<T>(id + typeof(T).ToString());
            }
            catch (Exception ex)
            {
                ex.Print();
            }
        }

        public async Task DeleteAllAsync<T>()
        {
            try
            {
                await BlobCache.InMemory.InvalidateAllObjects<T>();
            }
            catch (Exception ex)
            {
                ex.Print();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            try
            {
                return await BlobCache.InMemory.GetAllObjects<T>();
            }
            catch (Exception ex)
            {
                ex.Print();
            }

            return default;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(Func<T, bool> predExpr)
        {
            try
            {
                var list = await GetAllAsync<T>();

                return list?.Where(predExpr);
            }
            catch (Exception ex)
            {
                ex.Print();
            }

            return default;
        }
    }
}
