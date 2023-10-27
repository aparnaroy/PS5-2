using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCTOBER.EF.Models
{
    [Table("EMPLOYEES")]
    [Index("Email", Name = "EMP_EMAIL_UK", IsUnique = true)]
    [Index("LastName", "FirstName", Name = "EMP_NAME_IX")]
    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            Employeephones = new HashSet<Employeephone>();
            Employments = new HashSet<Employment>();
        }

        [Key]
        [Column("EMPLOYEE_ID")]
        [Precision(6)]
        public int EmployeeId { get; set; }
        [Column("FIRST_NAME")]
        [StringLength(20)]
        [Unicode(false)]
        public string? FirstName { get; set; }
        [Column("LAST_NAME")]
        [StringLength(25)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [Column("EMAIL")]
        [StringLength(25)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [Column("HIRE_DATE", TypeName = "DATE")]
        public DateTime HireDate { get; set; }

        [InverseProperty("Manager")]
        public virtual ICollection<Department> Departments { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Employeephone> Employeephones { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
