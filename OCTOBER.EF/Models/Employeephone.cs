using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCTOBER.EF.Models
{
    [Table("EMPLOYEEPHONE")]
    public partial class Employeephone
    {
        [Key]
        [Column("EMPLOYEE_PHONE_ID")]
        [Precision(6)]
        public int EmployeePhoneId { get; set; }
        [Column("EMPLOYEE_ID")]
        [Precision(6)]
        public int? EmployeeId { get; set; }
        [Column("PHONE_NUMBER")]
        [StringLength(20)]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Employeephones")]
        public virtual Employee? Employee { get; set; }
    }
}
