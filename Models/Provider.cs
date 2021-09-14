using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PhyndDemo_v2.Models
{
    [Table("provider")]
    [Index(nameof(HospitalId), Name = "hospitalId")]
    public partial class Provider
    {
        public Provider()
        {
            Providerprograms = new HashSet<Providerprogram>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("firstName")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [Column("middleName")]
        [StringLength(30)]
        public string MiddleName { get; set; }
        [Column("lastName")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column("hospitalId", TypeName = "int(11)")]
        public int HospitalId { get; set; }
        [Column("createdOn")]
        public DateTime CreatedOn { get; set; }
        [Column("isDeleted")]
        public bool? IsDeleted { get; set; }
        [Column("createdBy", TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        [Column("modifiedBy", TypeName = "int(11)")]
        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(HospitalId))]
        [InverseProperty("Providers")]
        public virtual Hospital Hospital { get; set; }
        [InverseProperty(nameof(Providerprogram.Provider))]
        public virtual ICollection<Providerprogram> Providerprograms { get; set; }
    }
}
