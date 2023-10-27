using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCTOBER.EF.Models
{
    [Table("SALARY")]
    public partial class Salary
    {
        [Key]
        [Column("SALARY_ID")]
        [Precision(6)]
        public int SalaryId { get; set; }
        [Column("EMPLOYEE_ID")]
        [Precision(6)]
        public int? EmployeeId { get; set; }
        [Column("START_DATE", TypeName = "DATE")]
        public DateTime? StartDate { get; set; }
        [Column("SALARY", TypeName = "NUMBER(8,2)")]
        public decimal? Salary1 { get; set; }
        [Column("COMMISSION_PCT", TypeName = "NUMBER(2,2)")]
        public decimal? CommissionPct { get; set; }

        [ForeignKey("EmployeeId,StartDate")]
        [InverseProperty("Salaries")]
        public virtual Employment? Employment { get; set; }
    }
}
