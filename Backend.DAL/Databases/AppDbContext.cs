using Backend.BO.Commons;
using Backend.BO.Constants;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Admin",
                    Email = "adminexample@gmail.com",
                    Password = "reallystrongpass!123",
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Trung",
                    LastName = "Nguyen",
                    Email = "trung@example.com",
                    Password = "password123",
                    Role = UserRole.User,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Linh",
                    LastName = "Pham",
                    Email = "linh@example.com",
                    Password = "password456",
                    Role = UserRole.User,
                }
            );
        }
    }
}
