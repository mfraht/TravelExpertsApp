using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMaintenance.TravelExpertsModels
{
    public partial class Affiliations
    {
        public Affiliations()
        {
            SupplierContacts = new HashSet<SupplierContacts>();
        }

        [Key]
        [StringLength(10)]
        public string AffilitationId { get; set; }
        [StringLength(50)]
        public string AffName { get; set; }
        [StringLength(50)]
        public string AffDesc { get; set; }

        [InverseProperty("Affiliation")]
        public virtual ICollection<SupplierContacts> SupplierContacts { get; set; }
    }
}
