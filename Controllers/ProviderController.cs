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
using PhyndDemo_v2.DTOs;
using AutoMapper;

namespace PhyndDemo_v2.Controllers
{
    //[Authorize]
    [Route("providers")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        //private readonly phynd2Context context;
        private readonly IProviderRepository dataRepository;
        private readonly IMapper mapper;

        public ProviderController(IProviderRepository dataRepository,IMapper mapper)
        {
            //this.context = context;
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        } 

        [HttpGet]
        public ActionResult<IEnumerable<ProviderCreationDTO>> Get()
        {
            var providers = dataRepository.GetProviders();
            //IEnumerable<Provider> providers = dataRepository.GetProviders();
            //return Ok(providers);
            return Ok(mapper.Map<IEnumerable<ProviderCreationDTO>>(providers));
        }

        
        [HttpGet("{Id}", Name = "GetProvider")] 
        public IActionResult Get(int Id)
        {
            var providerfromRepo = dataRepository.GetProvider(Id);
            return Ok(mapper.Map<ProviderCreationDTO>(providerfromRepo)); ;
        }

        [HttpPost]
        public ActionResult<ProviderDTO> Post(ProviderDTO provider)
        {
            var newProvider = mapper.Map<Provider>(provider);
            dataRepository.AddProvider(newProvider);
            return CreatedAtRoute("GetProvider",new{Id = provider.Id},provider);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id) 
        { 
            var provider=dataRepository.GetProvider(id);
            if(provider!=null)
            { 
                dataRepository.DeleteProvider(provider);
                return Ok();
            }
            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] ProviderDTO providerDTO)
        {


            if (providerDTO == null)
            {
                return BadRequest("Provider is null.");
            }
            Provider providerToUpdate = dataRepository.GetProvider(Id);
            if (providerToUpdate == null)
            {
                return NotFound("Provider not found.");
            }
            dataRepository.Update(providerToUpdate, providerDTO);
            return Accepted();

        }
    }
}
