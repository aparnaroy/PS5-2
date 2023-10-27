using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCTOBER.EF.Models
{
    [Table("DEPARTMENTS")]
    [Index("LocationId", Name = "DEPT_LOCATION_IX")]
    public partial class Department
    {
        public Department()
        {
            Employments = new HashSet<Employment>();
        }

        [Key]
        [Column("DEPARTMENT_ID")]
        [Precision(4)]
        public byte DepartmentId { get; set; }
        [Column("DEPARTMENT_NAME")]
        [StringLength(30)]
        [Unicode(false)]
        public string DepartmentName { get; set; } = null!;
        [Column("MANAGER_ID")]
        [Precision(6)]
        public int? ManagerId { get; set; }
        [Column("LOCATION_ID")]
        [Precision(4)]
        public byte? LocationId { get; set; }

        [ForeignKey("LocationId")]
        [InverseProperty("Departments")]
        public virtual Location? Location { get; set; }
        [ForeignKey("ManagerId")]
        [InverseProperty("Departments")]
        public virtual Employee? Manager { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
