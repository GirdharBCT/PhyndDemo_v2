using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly phynd2Context context;

        public UserController(phynd2Context context)
        {
            this.context = context;

        }

        [HttpGet] 
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await context.Users.AsNoTracking().ToListAsync();
            //var genresDTOs = mapper.Map<List<GenreDTO>>(genres);
            return users;

        }

        [HttpGet("{Id:int}", Name = "getUser")] 
        public async Task<ActionResult<User>> Get(int Id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (user == null)
            {
                return NotFound();
            }
            //var genreDTO = mapper.Map<GenreDTO>(genre);

            return user;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            //var genre = mapper.Map<Genre>(genreCreation);
            context.Add(user);
            await context.SaveChangesAsync();
            //var genreDTO = mapper.Map<GenreDTO>(genre);

            return new CreatedAtRouteResult("getuser", new { user.Id }, User);
        }
    }
}
