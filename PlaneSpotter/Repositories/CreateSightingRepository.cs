using Microservices.Common.Models.PlaneSpotter;
using Microservices.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter.Repositories
{
    public interface ICreateSightingRepository
    {
        Task<Sighting> CreateAsync(Sighting sighting);
    }
    public class CreateSightingRepository : GenericRepository<Sighting>, ICreateSightingRepository
    {
        public CreateSightingRepository(CommonDbContext context) : base(context)
        {

        }

        public async Task<Sighting> CreateAsync(Sighting sighting)
        {
            var response = await AddAsync(sighting);
            return response;
        }
    }
}
