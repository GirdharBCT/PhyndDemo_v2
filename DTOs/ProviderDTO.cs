using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.DTOs
{
    public class ProviderDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int HospitalId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
