using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public interface IPersonService
    {
        Task<PersonItem> GetPersonDetailAsync(int id);
        Task<PersonsCreditResult> GetPersonsCreditsAsync(int id);
    }
}
