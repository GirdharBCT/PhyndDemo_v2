using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Managers
{
    public interface IDataRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void Add(UserDTO entity);
        void Update(User dbentity, UserDTO entity);
        void Delete(User entity);
        IEnumerable<User> GetUsers(string sortByfirstName, string sortBylastName, string search);
        IEnumerable<Provider> GetProviders(string sortByfirstName, string sortBylastName, string search);
        User CheckUser(string email, string password);
    }
}
