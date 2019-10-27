using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestTriangle.Entities.Modesl
{
    public partial class TestTriangleContext : DbContext
    {
        public TestTriangleContext()
        {
        }

        public TestTriangleContext(DbContextOptions<TestTriangleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestTriangle;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Country1)
                    .HasColumnName("Country")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Addresss).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.HomePhone).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.PostalCode).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });
        }
    }
}
