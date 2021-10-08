using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMaintenance.Models
{
    public partial class States
    {
        public States()
        {
            Customers = new HashSet<Customers>();
        }

        [Key]
        [StringLength(2)]
        public string StateCode { get; set; }
        [Required]
        [StringLength(20)]
        public string StateName { get; set; }
        public int FirstZipCode { get; set; }
        public int LastZipCode { get; set; }

        [InverseProperty("StateNavigation")]
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
