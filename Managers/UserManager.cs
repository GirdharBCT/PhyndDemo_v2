using AutoMapper;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Managers
{
    public class UserManager : IUserRepository
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

        public IEnumerable<User> GetUsers(Params userParams)
        {
            if (userParams == null)
            {
                throw new ArgumentNullException(nameof(userParams));
            }

            if (string.IsNullOrWhiteSpace(userParams.sortByFirstName)
                && string.IsNullOrWhiteSpace(userParams.sortByLastName)
                && string.IsNullOrWhiteSpace(userParams.Search))
            {
                return GetUsers();
            }

            var collection = context.Users as IQueryable<User>;
            if (!string.IsNullOrWhiteSpace(userParams.sortByFirstName))
            {
                var firstName = userParams.sortByFirstName.Trim();
                collection = collection.Where(a => a.FirstName == firstName);
            }
            if (!string.IsNullOrWhiteSpace(userParams.sortByLastName))
            {

                var lastName = userParams.sortByLastName.Trim();
                collection = collection.Where(a => a.LastNmae == lastName);

            }

            if (!string.IsNullOrWhiteSpace(userParams.Search))
            {
                var search = userParams.Search.Trim();
                return collection.Where(a => a.FirstName.Contains(search) || a.LastNmae.Contains(search));
            }

            
            return collection.ToList();

        }


        public User LoginUser(string email, string password)
        {
            return context.Users.SingleOrDefault(u => u.Email == email & u.Password == password);
        }

    }
}
