using AutoMapper;
using Microservices.Common.Models.PlaneSpotter;
using PlaneSpotter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter.Mapping
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<SightingViewModel, Sighting>();
 
        }
    }
}
