using CinematicsXF.Core.Dto.Search;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public class SearchService : BaseService, ISearchService
    {
        public async Task<SearchResultItem> SearchAsync(string query)
        {
            try
            {
                var res = await MakeRequestAsync<SearchResultDto>(string.Format(ServiceConfig.Search, query), HttpMethod.Get);

                return new SearchResultItem
                {
                    Movies = res.Results?.Where(x => x.MediaType == MediaType.Movie)?.Select(movie => movie.ToMovieItem()),
                    Persons = res.Results?.Where(x => x.MediaType == MediaType.Person)?.Select(person => person.ToPersonItem())
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
