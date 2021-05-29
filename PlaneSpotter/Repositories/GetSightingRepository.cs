using Microservices.Common.Models.PlaneSpotter;
using Microservices.Common.Repositories;
using PlaneSpotter.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter.Repositories
{

    public interface IGetSightingRepository
    {
        Task<IEnumerable<Sighting>> GetAllSlightsAsync();
        Task<Sighting> GetByIdAsync(int id);
        Task<IEnumerable<Sighting>> SearchAsync(SearchDTO searchDTO);
    }
    public class GetSightingRepository : GenericRepository<Sighting>, IGetSightingRepository
    {

        public GetSightingRepository(CommonDbContext context) : base(context)
        {

        }

        /// <summary>Gets all slights asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IEnumerable<Sighting>> GetAllSlightsAsync()
        {
            return await GetAllAsync();
        }

        /// <summary>Gets the by identifier asynchronous.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Sighting> GetByIdAsync(int id)
        {
            var result = await FindByAsync(x => x.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Sighting>> SearchAsync(SearchDTO searchDTO)
        {

            return await FindByAsync(x => x.Make.Contains(searchDTO.Make)
            && x.Model.Contains(searchDTO.Model)
           && x.Registration.Contains(searchDTO.Registration));
        }
    }
}
