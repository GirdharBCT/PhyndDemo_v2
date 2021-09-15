using AutoMapper;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Managers
{
    public class UserManager : IDataRepository
    {
        private readonly phynd2Context context;
        private readonly IMapper mapper;

        public UserManager(phynd2Context context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }
        public void Add(UserDTO entity)
        {
            var newUser = mapper.Map<User>(entity);
            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return context.Users.SingleOrDefault(u => u.Id == id);
        }
        public void Update(User user, UserDTO newUser)
        {
            var entity = mapper.Map<User>(newUser);

            user.firstName = entity.firstName;
            user.LastNmae = entity.LastNmae;
            user.Password = entity.Password;
            user.Email = entity.Email;
            user.IsDeleted = entity.IsDeleted;
            user.UserHospitalId = entity.UserHospitalId;

            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
            context.SaveChanges();
        }

        //--------------------------------------------------------------------------------------

        //public void Add(UserDTO entity)
        //{
        //    //throw new NotImplementedException();
        //    var newUser = mapper.Map<User>(entity);
        //    context.Users.Add(newUser);
        //    context.SaveChanges();
        //}

        //public void Update(User dbentity, User entity)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<User> GetUsers(string sortByfirstName, string sortBylastName, string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provider> GetProviders(string sortByfirstName, string sortBylastName, string search)
        {
            throw new NotImplementedException();
        }

        public User CheckUser(string email, string password)
        {
            throw new NotImplementedException();
        }

    }
}
