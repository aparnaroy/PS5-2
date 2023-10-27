using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCTOBER.EF.Models
{
    [Table("EMPLOYMENT")]
    [Index("DepartmentId", Name = "JHIST_DEPARTMENT_IX")]
    [Index("EmployeeId", Name = "JHIST_EMPLOYEE_IX")]
    [Index("JobId", Name = "JHIST_JOB_IX")]
    public partial class Employment
    {
        public Employment()
        {
            Salaries = new HashSet<Salary>();
        }

        [Key]
        [Column("EMPLOYEE_ID")]
        [Precision(6)]
        public int EmployeeId { get; set; }
        [Key]
        [Column("START_DATE", TypeName = "DATE")]
        public DateTime StartDate { get; set; }
        [Column("END_DATE", TypeName = "DATE")]
        public DateTime EndDate { get; set; }
        [Column("JOB_ID")]
        [StringLength(10)]
        [Unicode(false)]
        public string JobId { get; set; } = null!;
        [Column("DEPARTMENT_ID")]
        [Precision(4)]
        public byte? DepartmentId { get; set; }
        [Column("MANAGER_ID")]
        [Precision(6)]
        public int? ManagerId { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("Employments")]
        public virtual Department? Department { get; set; }
        [ForeignKey("EmployeeId")]
        [InverseProperty("Employments")]
        public virtual Employee Employee { get; set; } = null!;
        [ForeignKey("JobId")]
        [InverseProperty("Employments")]
        public virtual Job Job { get; set; } = null!;
        [InverseProperty("Employment")]
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
