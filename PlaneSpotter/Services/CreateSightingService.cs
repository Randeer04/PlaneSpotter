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
    public interface ICreateSightingService
    {
        Task<SightingViewModel> CreateAsync(SightingViewModel sighting);
    }
    public class CreateSightingService : ICreateSightingService
    {
        private readonly ICreateSightingRepository _createSightingRepository;
        private readonly IMapper _mapper;

        public CreateSightingService(ICreateSightingRepository createSightingRepository, IMapper mapper)
        {
            _createSightingRepository = createSightingRepository;
            _mapper = mapper;
        }
        public async Task<SightingViewModel> CreateAsync(SightingViewModel sighting)
        {
            Validate(sighting);
            var model = _mapper.Map<Sighting>(sighting);
            var response = await _createSightingRepository.CreateAsync(model);
            return _mapper.Map<SightingViewModel>(response);
        }

        #region Validation
        private void Validate(SightingViewModel sighting)
        {
            #region Validate Make
            if(string.IsNullOrWhiteSpace(sighting.Make))
                throw new Exception("Make Required");
            #endregion

            #region Validate Model
            if (string.IsNullOrWhiteSpace(sighting.Model))
                throw new Exception("Model Required");
            #endregion

            #region Validate Registration

            if (string.IsNullOrWhiteSpace(sighting.Registration))
                throw new Exception("Registration Required");
            if (!sighting.Registration.Contains("-")
                || sighting.Registration.Count(x => x == '-')>1
                || sighting.Registration.Split('-', '*')[0].Count()>2
                || sighting.Registration.Split('-', '*')[1].Count() > 5)
                throw new Exception("Invalid Registration");

            #endregion

            #region Validate Location
            if (string.IsNullOrWhiteSpace(sighting.Location))
                throw new Exception("Make Required");
            #endregion

            #region validate Date 
            if (sighting.SightingDate > DateTime.Today)
                throw new Exception("Date should be past");
            #endregion

        }
        #endregion
    }
}
