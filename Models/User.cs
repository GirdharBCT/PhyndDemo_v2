using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PhyndDemo_v2.Models
{
    [Table("user")]
    [Index(nameof(UserHospitalId), Name = "userHospitalId")]
    public partial class User
    {
        internal string firstName;

        public User()
        {
            Userroles = new HashSet<Userrole>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        //[Required]
        //[Column("userName")]
        //[StringLength(100)]
        //public string UserName { get; set; }
        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [Column("firstName")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [Column("lastNmae")]
        [StringLength(100)]
        public string LastNmae { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("userHospitalId", TypeName = "int(11)")]
        public int UserHospitalId { get; set; }
        [Column("createdOn")]
        public DateTime CreatedOn { get; set; }
        [Column("modifiedOn")]
        public DateTime ModifiedOn { get; set; }
        [Column("isDeleted")]
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(UserHospitalId))]
        [InverseProperty(nameof(Hospital.Users))]
        public virtual Hospital UserHospital { get; set; }
        [InverseProperty(nameof(Userrole.User))]
        public virtual ICollection<Userrole> Userroles { get; set; }
    }
}
