using AutoMapper;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Managers
{
    public class ProgramManager
    {
        private readonly phynd2Context context;
        private readonly IMapper mapper;

        public ProgramManager(phynd2Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<Program> GetPrograms()
        {
            return context.Program.ToList();
        }
    }
}