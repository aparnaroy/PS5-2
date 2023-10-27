using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCTOBER.EF.Models
{
    [Table("LOCATIONS")]
    [Index("City", Name = "LOC_CITY_IX")]
    [Index("CountryId", Name = "LOC_COUNTRY_IX")]
    [Index("StateProvince", Name = "LOC_STATE_PROVINCE_IX")]
    public partial class Location
    {
        public Location()
        {
            Departments = new HashSet<Department>();
        }

        [Key]
        [Column("LOCATION_ID")]
        [Precision(4)]
        public byte LocationId { get; set; }
        [Column("STREET_ADDRESS")]
        [StringLength(40)]
        [Unicode(false)]
        public string? StreetAddress { get; set; }
        [Column("POSTAL_CODE")]
        [StringLength(12)]
        [Unicode(false)]
        public string? PostalCode { get; set; }
        [Column("CITY")]
        [StringLength(30)]
        [Unicode(false)]
        public string City { get; set; } = null!;
        [Column("STATE_PROVINCE")]
        [StringLength(25)]
        [Unicode(false)]
        public string? StateProvince { get; set; }
        [Column("COUNTRY_ID")]
        [StringLength(2)]
        [Unicode(false)]
        public string? CountryId { get; set; }

        [ForeignKey("CountryId")]
        [InverseProperty("Locations")]
        public virtual Country? Country { get; set; }
        [InverseProperty("Location")]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
