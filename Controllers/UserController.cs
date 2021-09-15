using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Models;
using PhyndDemo_v2.Managers;
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
        private readonly IDataRepository dataRepository;

        public UserController(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        [HttpGet] 
        public IActionResult Get()
        {
            {//var users = await context.Users.AsNoTracking().ToListAsync();
             //var userDTOs = mapper.Map<List<UserDTO>>(users);
             //return userDTOs;
            }
            IEnumerable<User> users = dataRepository.GetUsers();
            return Ok(users);

        }

        [HttpGet("{Id:int}", Name = "getUser")]
        public IActionResult Get(int Id)
        {
            {//var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            //if (user == null)
            //{
            //    return NotFound();
            //}
            ////var genreDTO = mapper.Map<GenreDTO>(genre);
            //return user;
            }
            User user = dataRepository.GetUser(Id);
            if (user == null)
            {
                return NotFound("User record not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDTO user)
        {
            {////var genre = mapper.Map<Genre>(genreCreation);
             //context.Add(user);
             //await context.SaveChangesAsync();
             ////var genreDTO = mapper.Map<GenreDTO>(genre);

                //return new CreatedAtRouteResult("getuser", new { user.Id }, User);
            }
            if (user == null)
            {
                return BadRequest("User is null.");
            }
            dataRepository.Add(user);
            //return new CreatedAtRouteResult("getuser", new { user.Id }, User);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);

        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] UserDTO user)
        {
            {//var putuser = mapper.Map<User>(user);
             //putuser.Id = Id;
             //context.Entry(putuser).State = EntityState.Modified;
             //await context.SaveChangesAsync();
             //return NoContent();
             //--------------------------------------

                //if (user == null)
                //{
                //    return BadRequest("User is null.");
                //}
                //User userToUpdate = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
                //if (userToUpdate == null)
                //{
                //    return NotFound("User not found.");
                //}
                //dataRepository.Update(userToUpdate, user);
                //return Accepted();
            }


            if (user == null)
            {
                return BadRequest("User is null.");
            }
            User userToUpdate = dataRepository.GetUser(Id);
            if (userToUpdate == null)
            {
                return NotFound("User not found.");
            }
            dataRepository.Update(userToUpdate, user);
            return Accepted();
            {//var userDB = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);

                //if (userDB == null) { return NotFound(); }
                //var putuser = mapper.Map<User>(user);
                //putuser.Id = Id;
                //context.Entry(putuser).State = EntityState.Modified;
                //await context.SaveChangesAsync();
                //return NoContent();

                //userDB = mapper.Map(UserCreationDTO, userDB);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            {//var exist = await context.Users.AnyAsync(x => x.Id == id);
             //if (!exist)
             //{
             //    return NotFound();
             //}
             //context.Remove(new User() { Id = id });
             //await context.SaveChangesAsync();
             //return NoContent();
            }
            User user = dataRepository.GetUser(id);
            if (user == null)
            {
                return NotFound("User record not found.");
            }
            dataRepository.Delete(user);
            return NoContent();
        }
    }
}
