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
    [Route("programs")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        //private readonly phynd2Context context;
        private readonly IProgramRepository dataRepository;
        private readonly IMapper mapper;

        public ProgramController(IProgramRepository dataRepository, IMapper mapper)
        {
            //this.context = context;
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProgramCreationDTO>> Get()
        {
            var programs = dataRepository.GetPrograms();
            //IEnumerable<Provider> providers = dataRepository.GetProviders();
            //return Ok(providers);
            return Ok(mapper.Map<IEnumerable<ProviderCreationDTO>>(programs));
        }


        [HttpGet("{Id}", Name = "GetProgram")]
        public IActionResult Get(int Id)
        {
            var programfromRepo = dataRepository.GetProgram(Id);
            return Ok(mapper.Map<ProgramCreationDTO>(programfromRepo)); 
        }

        [HttpPost]
        public ActionResult<ProgramDTO> Post(ProgramDTO program)
        {
            var newProgram = mapper.Map<Models.Program>(program);
            dataRepository.AddProgram(newProgram);
            return CreatedAtRoute("GetProgram", new { Id = program.Id }, program);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var program = dataRepository.GetProgram(id);
            if (program != null)
            {
                dataRepository.DeleteProgram(program);
                return Ok();
            }
            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] ProgramDTO programDTO)
        {


            if (programDTO == null)
            {
                return BadRequest("Program is null.");
            }
            Models.Program programToUpdate = dataRepository.GetProgram(Id);
            if (programToUpdate == null)
            {
                return NotFound("Program not found.");
            }
            dataRepository.Update(programToUpdate, programDTO);
            return Accepted();

        }
    }
}
