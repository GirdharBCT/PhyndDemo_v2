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

        [HttpGet]
        public IActionResult Get()
        {
            //var providers = await context.Providers.AsNoTracking().ToListAsync();
            ////var genresDTOs = mapper.Map<List<GenreDTO>>(genres);
            //return providers;
            IEnumerable<Provider> providers = dataRepository.GetProviders();
            return Ok(providers);
        }

        
        [HttpGet("{Id}", Name = "GetProvider")] 
        public IActionResult Get(int Id)
        {
            var providerfromRepo = dataRepository.GetProvider(Id);

            if (providerfromRepo == null)
            {
                return NotFound();
            }
            return Ok(providerfromRepo);
        }

        [HttpPost]
        public IActionResult<Provider> Post(Provider provider)
        {
            dataRepository.AddProvider(provider);
            dataRepository.Save();

            return CreatedAtRoute("GetProvider",new{Id = provider.Id},provider);
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        { 
            var provider=dataRepository.GetProvider(id);
            if(provider!=null)
            { 
                dataRepository.DeleteProvider(provider);
                dataRepository.Save();
                return Ok();
            }
            return NoContent();
        }

        [HttpPatch]
        public IActionResult Edit(int id,Provider provider) {
            var existingProvider=dataRepository.GetProvider(id);
            if (existingProvider != null) { 
                provider.Id=existingProvider.Id;
                dataRepository.EditProvider(provider);
            }
            return Ok(provider);
        }
    }
}
