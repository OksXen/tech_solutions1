using TechSolutionsLibs.Model;
using Microsoft.EntityFrameworkCore;

namespace TechSolutionsLibs.Provider
{
    public partial class ActivityDBContext : DbContext
    {
        public virtual DbSet<EmployeeActivity> EmployeeActivity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Data Source=tcp:s19.winhost.com;Initial Catalog=DB_127750_activity;User ID=DB_127750_activity_user;Password=th8uxgWBLf8M;Integrated Security=False;");
            }
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
