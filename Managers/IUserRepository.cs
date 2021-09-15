using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Managers
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void Add(UserDTO entity);
        void Update(User dbentity, UserDTO entity);
        void Delete(User entity);
        IEnumerable<User> GetUsers(Params userParams);
        User LoginUser(string email, string password);
    }
}
