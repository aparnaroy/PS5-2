using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCTOBER.EF.Models
{
    [Table("REGIONS")]
    public partial class Region
    {
        public Region()
        {
            Countries = new HashSet<Country>();
        }

        [Key]
        [Column("REGION_ID", TypeName = "NUMBER")]
        public decimal RegionId { get; set; }
        [Column("REGION_NAME")]
        [StringLength(25)]
        [Unicode(false)]
        public string? RegionName { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<Country> Countries { get; set; }
    }
}
