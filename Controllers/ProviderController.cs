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
    [Route("providers")]
    [ApiController]
    public class ProviderController : Controller
    {
        private readonly phynd2Context context;
        private readonly ProviderManager dataRepository;

        public ProviderController(phynd2Context context,ProviderManager dataRepository)
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

            IEnumerable<Provider> providers = dataRepository.GetProviders();
            return Ok(providers);
        }
        
    }
}
