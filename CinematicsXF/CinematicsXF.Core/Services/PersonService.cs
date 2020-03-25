using CinematicsXF.Core.Dto.PersonDetail;
using CinematicsXF.Core.Dto.PersonsCredits;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public class PersonService : BaseService, IPersonService
    {
        public async Task<PersonItem> GetPersonDetailAsync(int id)
        {
            try
            {
                // Check memory cache first
                var person = await MemoryRepository.Current.LoadAsync<PersonItem>(MemoryKey.PersonDetail + id);

                if (person != null)
                {
                    return person;
                }

                // Make request
                var res = await MakeRequestAsync<PersonDetailResultDto>(string.Format(ServiceConfig.GetPersonDetails, id), HttpMethod.Get);

                // Create person
                person = res.ToPersonItem();

                // Save in memory cache
                await MemoryRepository.Current.SaveAsync(MemoryKey.PersonDetail + id, person);

                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<PersonsCreditResult> GetPersonsCreditsAsync(int id)
        {
            try
            {
                // Check memory cache
                var personsCredit = await MemoryRepository.Current.LoadAsync<PersonsCreditResult>(MemoryKey.PersonsCredits + id);

                if (personsCredit != null)
                {
                    return personsCredit;
                }

                var res = await MakeRequestAsync<PersonsCreditsResultDto>(string.Format(ServiceConfig.GetCombinedCredits, id), HttpMethod.Get);

                personsCredit = new PersonsCreditResult
                {
                    Movies = res.Cast?.Where(movie => movie.MediaType == MediaType.Movie).Select(movie => movie.ToMovieItem())
                };

                await MemoryRepository.Current.SaveAsync(MemoryKey.PersonsCredits + id, personsCredit);

                return personsCredit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
