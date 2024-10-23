using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagement.Models
{
    public class EmployeeTaskDbContext : IdentityDbContext<IdentityUser>
    {
        public EmployeeTaskDbContext(DbContextOptions<EmployeeTaskDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTask> EmployeeTask { get; set; }

        public DbSet<EmployeeRole> EmployeeRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Make sure to call this
            modelBuilder.Entity<EmployeeTask>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired(false);

                entity.Property(e => e.Status)
                    .IsRequired();

                entity.Property(e => e.AssignedFrom)
                    .IsRequired();

                entity.Property(e => e.AssignedTo)
                    .IsRequired();

                entity.Property(e => e.CreatedDate)
                    .IsRequired();

                entity.Property(e => e.DueDate);
                   // .IsRequired(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(u => u.EmployeeRole)
                    .WithMany()
                    .HasForeignKey("RoleId");

                entity.HasMany(u => u.EmployeeTask)
                    .WithOne()
                    .HasForeignKey("UserId");
            });


            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.RoleName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
