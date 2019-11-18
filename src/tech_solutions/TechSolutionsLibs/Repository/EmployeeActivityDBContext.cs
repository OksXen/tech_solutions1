using Microsoft.EntityFrameworkCore;
using TechSolutionsLibs.Models;
using TechSolutionsLibs.Settings.Interface;

namespace TechSolutionsLibs.Settings
{
    public class EmployeeActivityDBContext : DbContext, IEmployeeActivityDBContext
    {
        IDBSettings _iDBSettings;

        public virtual DbSet<EmployeeActivity> EmployeeActivity { get; set; }
        

        public EmployeeActivityDBContext(IDBSettings dBSettings)
        {
            _iDBSettings = dBSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer(_iDBSettings.ConnectionString);
            }
        }

        public new void  SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeActivity>(entity =>
            {

                entity.Property(e => e.FirstName)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.LastName)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.ActivityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                   .HasMaxLength(1000)
                   .IsUnicode(false);
            });


        }
    }
}
