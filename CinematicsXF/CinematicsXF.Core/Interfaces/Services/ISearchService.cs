using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public interface ISearchService
    {
        Task<SearchResultItem> SearchAsync(string query);
    }
}
