using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWebApi.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.Property(e => e.ImageName).IsUnicode(false);
                entity.Property(e => e.ImageUrl).IsUnicode(false);
                entity.Property(e => e.JoinDate).HasColumnType("date");
                entity.Property(e => e.EmployeeName).HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience");
                entity.Property(e => e.Title).HasMaxLength(50).IsUnicode(false);
                entity.HasOne(d => d.Employee)
                      .WithMany(p => p.Experiences)
                      .HasForeignKey(d => d.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_Experience_Employee");
            });
       

            
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeName = "Ashik Mahmud",
                    IsActive = true,
                    Email = "ashik@gmail.com",
                    JoinDate = new DateTime(2020, 01, 15),
                    ImageName = "ashik.jpg",
                    ImageUrl = "/Upload/mohipic.jpg"
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeName = "Mredul",
                    IsActive = true,
                    Email = "mredul@.com",
                    JoinDate = new DateTime(2021, 05, 10),
                    ImageName = "Mredul.jpg",
                    ImageUrl = "/Upload/Mredul.jpg"
                }
            );

           
            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    ExperienceId = 1,
                    EmployeeId = 1,
                    Title = "Software Developer",
                    Duration = 24
                },
                new Experience
                {
                    ExperienceId = 2,
                    EmployeeId = 1,
                    Title = "Senior Developer",
                    Duration = 12
                },
                new Experience
                {
                    ExperienceId = 3,
                    EmployeeId = 2,
                    Title = "Project Manager",
                    Duration = 36
                }
            );
        }

    }

}
