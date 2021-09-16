using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.Managers;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Controllers
{
    //[Authorize]
    [Route("programs")]
    [ApiController]
    public class ProgramController : Controller
    {
        private readonly phynd2Context context;
        private readonly ProgamRepository dataRepository;

        public ProgramController(phynd2Context context, ProviderRepository dataRepository)  //Program manager bnana hai 
        {
            this.context = context;
            this.dataRepository = dataRepository;
        }

        [HttpGet] //"providers"
        public IActionResult Get()
        {
            //var providers = await context.Providers.AsNoTracking().ToListAsync();
            ////var genresDTOs = mapper.Map<List<GenreDTO>>(genres);
            //return providers;

            IEnumerable<Program> program = dataRepository.GetPrograms();
            return Ok(programs);
        }
    }
}