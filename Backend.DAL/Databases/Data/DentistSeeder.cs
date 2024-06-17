using Backend.BO.Entities;
using Backend.BO.Enums;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases.Data
{
    public static class DentistSeeder
    {
        public static void SeedDentist(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dentist>().HasData(
                new Dentist
                {
                    Id = new Guid("6b4deeed-b92a-4b77-9977-5b74d9176f5a"),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "Password123!",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(1985, 1, 1),
                    Sex = (short)SexEnum.Male,
                },
                new Dentist
                {
                    Id = new Guid("504a1a7c-36f5-46f9-95f4-b56877a648f6"),
                    FirstName = "A",
                    LastName = "Nguyễn Văn",
                    Email = "nguyen.vana@gmail.com",
                    Password = "Password123!",
                    PhoneNumber = "0987654321",
                    DateOfBirth = new DateTime(1990, 4, 15),
                    Sex = (short)SexEnum.Male,
                },
                new Dentist
                {
                    Id = new Guid("0666d393-5502-4056-a2d4-b5433fa5d989"),
                    FirstName = "Ngọc",
                    LastName = "Bảo",
                    Email = "baongoc1234@gmail.com",
                    Password = "12345!",
                    PhoneNumber = "0912345678",
                    DateOfBirth = new DateTime(2003, 02, 12),
                    Sex = (short)SexEnum.Female,
                }
            );
        }
    }
}
