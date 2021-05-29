using AutoMapper;
using Microservices.Common.Models.PlaneSpotter;
using PlaneSpotter.DTO;
using PlaneSpotter.Repositories;
using PlaneSpotter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter.Services
{

    public interface IGetSightingService
    {
        Task<IEnumerable<SightingViewModel>> GetAllSlightsAsync();
        Task<SightingViewModel> GetByIdAsync(int id);
        Task<IEnumerable<SightingViewModel>> SearchAsync(SearchDTO searchDTO);
    }
    public class GetSightingService: IGetSightingService
    {
        private readonly IGetSightingRepository _getSightingRepository;
        private readonly IMapper _mapper;

        public GetSightingService(IGetSightingRepository getSightingRepository, IMapper mapper)
        {
            _getSightingRepository = getSightingRepository;
            _mapper = mapper;
        }
        /// <summary>Gets all slights asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IEnumerable<SightingViewModel>> GetAllSlightsAsync()
        {
            var result = await _getSightingRepository.GetAllSlightsAsync();
            return _mapper.Map<IEnumerable<SightingViewModel>>(result);
        }
        /// <summary>Gets the by identifier asynchronous.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<SightingViewModel> GetByIdAsync(int id)
        {
            var result = await _getSightingRepository.GetByIdAsync(id);
            return _mapper.Map<SightingViewModel>(result);
        }
        public async Task<IEnumerable<SightingViewModel>> SearchAsync(SearchDTO searchDTO)
        {
            var result = await _getSightingRepository.SearchAsync(searchDTO);
            return _mapper.Map<IEnumerable<SightingViewModel>>(result);
        }
    }
}
