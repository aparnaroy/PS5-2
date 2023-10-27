using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OCTOBER.EF.Models
{
    [Table("JOBS")]
    public partial class Job
    {
        public Job()
        {
            Employments = new HashSet<Employment>();
        }

        [Key]
        [Column("JOB_ID")]
        [StringLength(10)]
        [Unicode(false)]
        public string JobId { get; set; } = null!;
        [Column("JOB_TITLE")]
        [StringLength(35)]
        [Unicode(false)]
        public string JobTitle { get; set; } = null!;
        [Column("MIN_SALARY")]
        [Precision(6)]
        public int? MinSalary { get; set; }
        [Column("MAX_SALARY")]
        [Precision(6)]
        public int? MaxSalary { get; set; }

        [InverseProperty("Job")]
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
