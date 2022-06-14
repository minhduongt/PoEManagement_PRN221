using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PoEManagementLib.DataAccess
{
    public partial class Prn221DBContext : DbContext
    {
        public Prn221DBContext()
        {
        }

        public Prn221DBContext(DbContextOptions<Prn221DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Bonu> Bonus { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LogWork> LogWorks { get; set; }
        public virtual DbSet<Recuitment> Recuitments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Employee");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cvimage)
                    .HasMaxLength(200)
                    .HasColumnName("CVImage");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Staus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Recuitment)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.RecuitmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Recuitment");
            });

            modelBuilder.Entity<Bonu>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BonusMoney).HasColumnType("money");

                entity.Property(e => e.Fine).HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bonus_Employee");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DoB).HasColumnType("datetime");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<LogWork>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LogWork");

                entity.Property(e => e.EndWorkingTime).HasColumnType("time(0)");

                entity.Property(e => e.StartWorkingTime).HasColumnType("time(0)");

                entity.Property(e => e.WorkingDate).HasColumnType("date");

                entity.Property(e => e.WorkingTime).HasColumnType("time(0)");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogWork_Employee");
            });

            modelBuilder.Entity<Recuitment>(entity =>
            {
                entity.ToTable("Recuitment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
