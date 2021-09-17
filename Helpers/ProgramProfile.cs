using PhyndDemo_v2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhyndDemo_v2.Models;

namespace PhyndDemo_v2.Helpers
{
    public class ProgramProfile: Profile
    {
        public ProgramProfile()
        {
            CreateMap<Models.Program, ProgramCreationDTO>();
            CreateMap<Models.Program, ProgramDTO>();
            CreateMap<ProgramDTO, Models.Program>();
        }
    }
}
