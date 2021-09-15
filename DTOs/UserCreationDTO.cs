using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.DTOs
{
    public class UserCreationDTO
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastNmae { get; set; }
        public string Email { get; set; }
        public int UserHospitalId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
