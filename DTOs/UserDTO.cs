using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.DTOs
{
    public class UserDTO
    {
   
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastNmae { get; set; }
        public string Email { get; set; }
        public int UserHospitalId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        //public virtual ICollection<Userrole> Userroles { get; set; }
    }
}
