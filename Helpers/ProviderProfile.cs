using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Models;

namespace PhyndDemo_v2.Helpers
{
    public class ProviderProfile:Profile
    {
        public ProviderProfile()
        {
            CreateMap<Provider, ProviderCreationDTO>();
            CreateMap<Provider, ProviderDTO>();
            CreateMap<ProviderDTO, Provider>();
        }
    }
}
