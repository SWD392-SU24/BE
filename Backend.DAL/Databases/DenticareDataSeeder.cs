using Backend.BO.Commons;
using Backend.BO.Constants;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases
{
    public static class DenticareDataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = Guid.NewGuid(),
                     FirstName = "Admin",
                     Email = "adminexample@gmail.com",
                     Password = "reallystrongpass!123",
                     Role = UserRole.SystemAdmin,
                 },
                 new User
                 {
                     Id = Guid.NewGuid(),
                     FirstName = "Trung",
                     LastName = "Nguyen",
                     Email = "trung@example.com",
                     Password = "password123",
                     Role = UserRole.Customer,
                 },
                 new User
                 {
                     Id = Guid.NewGuid(),
                     FirstName = "Linh",
                     LastName = "Pham",
                     Email = "linh@example.com",
                     Password = "password456",
                     Role = UserRole.Customer,
                 }
            );
        }
    }
}
