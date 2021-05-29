using Microservices.Common.Models.PlaneSpotter;
using Microservices.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter.Repositories
{
    public interface IEditSightingRepository
    {
        Task<Sighting> EditAsync(Sighting sighting);
    }

    public class EditSightingRepository : GenericRepository<Sighting>, IEditSightingRepository
    {
        public EditSightingRepository(CommonDbContext context) : base(context) {}

        /// <summary>Edits the asynchronous.</summary>
        /// <param name="sighting">The sighting.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<Sighting> EditAsync(Sighting sighting)
        {
            var response = await AddAsync(sighting);
            return response;
        }
    }
}
