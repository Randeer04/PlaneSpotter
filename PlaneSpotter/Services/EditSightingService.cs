using AutoMapper;
using Microservices.Common.Models.PlaneSpotter;
using PlaneSpotter.Repositories;
using PlaneSpotter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter.Services
{
    public interface IEditSightingService
    {
        Task<SightingViewModel> EditAsync(SightingViewModel sighting);
    }
    public class EditSightingService : IEditSightingService
    {
        private readonly IEditSightingRepository _EditSightingRepository;
        private readonly IMapper _mapper;

        public EditSightingService(IEditSightingRepository EditSightingRepository, IMapper mapper)
        {
            _EditSightingRepository = EditSightingRepository;
            _mapper = mapper;
        }

        /// <summary>Edits the asynchronous.</summary>
        /// <param name="sighting">The sighting.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<SightingViewModel> EditAsync(SightingViewModel sighting)
        {
            var model = _mapper.Map<Sighting>(sighting);
            var response = await _EditSightingRepository.EditAsync(model);
            return _mapper.Map<SightingViewModel>(response);
        }
    }
}
