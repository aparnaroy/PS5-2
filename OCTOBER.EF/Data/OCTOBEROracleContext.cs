using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OCTOBER.EF.Models;

namespace OCTOBER.EF
{
    public partial class OCTOBEROracleContext : DbContext
    {
        public OCTOBEROracleContext()
        {
        }

        public OCTOBEROracleContext(DbContextOptions<OCTOBEROracleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Employeephone> Employeephones { get; set; } = null!;
        public virtual DbSet<Employment> Employments { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("UD_APARNAR")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).IsFixedLength();

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("COUNTR_REG_FK");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("DEPT_LOC_FK");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("DEPT_MGR_FK");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Employeephone>(entity =>
            {
                entity.Property(e => e.EmployeePhoneId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Employeephones)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("PHONE_EMP_ID_FK");
            });

            modelBuilder.Entity<Employment>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.StartDate })
                    .HasName("JHIST_EMP_ID_ST_DATE_PK");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("JHIST_DEPT_FK");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JHIST_EMP_FK");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JHIST_JOB_FK");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.CountryId).IsFixedLength();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("LOC_C_ID_FK");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.SalaryId).ValueGeneratedNever();

                entity.HasOne(d => d.Employment)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => new { d.EmployeeId, d.StartDate })
                    .HasConstraintName("SALARY_EMP_FK");
            });

            modelBuilder.HasSequence("EMPLOYEEPHONE_SEQ");

            modelBuilder.HasSequence("SALARY_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
