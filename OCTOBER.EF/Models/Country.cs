using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCTOBER.EF.Models
{
    [Table("COUNTRIES")]
    public partial class Country
    {
        public Country()
        {
            Locations = new HashSet<Location>();
        }

        [Key]
        [Column("COUNTRY_ID")]
        [StringLength(2)]
        [Unicode(false)]
        public string CountryId { get; set; } = null!;
        [Column("COUNTRY_NAME")]
        [StringLength(40)]
        [Unicode(false)]
        public string? CountryName { get; set; }
        [Column("REGION_ID", TypeName = "NUMBER")]
        public decimal? RegionId { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("Countries")]
        public virtual Region? Region { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<Location> Locations { get; set; }
    }
}
