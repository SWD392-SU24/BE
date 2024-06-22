using Backend.BO.Commons;
using Backend.BO.Constants;
using Backend.BO.Enums;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases.Data
{
    public static class UserSeeder
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("82213f2b-dc0b-400b-abef-1beda0231441"),
                    FirstName = "Hà",
                    LastName = "Phùng Trần Mai",
                    Email = "janetran639@gmail.com",
                    Password = "999doahoahong@",
                    PhoneNumber = "0902694265",
                    DateOfBirth = new DateTime(1987, 11, 11),
                    Address = "phường Phước Long A, Q.9, Tp.Hồ Chí Minh",
                    Sex = (short)SexEnum.Female,
                    Role = UserRole.Customer,
                },
                new User
                {
                    Id = new Guid("9e9da0b7-672d-448a-a392-bcc912e17cff"),
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Password = "Password123!",
                    PhoneNumber = "2345678901",
                    DateOfBirth = new DateTime(1990, 2, 2),
                    Address = "456 Oak St, Anytown, USA",
                    Sex = (short)SexEnum.Female,
                    Role = UserRole.Customer,
                },
                new User
                {
                    Id = new Guid("0d5db597-9210-45ef-be17-cdc57ed3b106"),
                    FirstName = "Bob",
                    LastName = "Brown",
                    Email = "bob.brown@example.com",
                    Password = "Password123!",
                    PhoneNumber = "3456789012",
                    DateOfBirth = new DateTime(1980, 3, 3),
                    Address = "789 Pine St, Anytown, USA",
                    Sex = (short)SexEnum.Male,
                    Role = UserRole.Customer,
                },
                new User
                {
                    Id = new Guid("18d2946a-1a58-4bd2-8044-5e6ace4833b5\r\n"),
                    FirstName = "Admin 01",
                    Email = "adminexample@gmail.com",
                    Password = "reallystrongpass!123",
                    Role = UserRole.SystemAdmin,
                },
                new User
                {
                    Id = new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"),
                    FirstName = "Nhật",
                    LastName = "Vũ Minh",
                    Email = "nhatvmse172011@fpt.edu.vn",
                    Password = "Password123!",
                    PhoneNumber = "0366412667",
                    DateOfBirth = new DateTime(2003, 8, 9),
                    Address = "Tân Bình, Tp.Hồ Chí Minh",
                    Sex = (short)SexEnum.Male,
                    Role = UserRole.Customer,
                },
                new User
                {
                    Id = new Guid("6fd69ed7-baa9-493d-bbde-b7546b9348a8"),
                    FirstName = "Bằng",
                    LastName = "Trần Lê Hữu",
                    Email = "bangtlhss170429@fpt.edu.vn",
                    Password = "Password123!",
                    PhoneNumber = "0384691554",
                    DateOfBirth = new DateTime(2003, 1, 1),
                    Address = "Thủ Đức, Tp.Hồ Chí Minh",
                    Sex = (short)SexEnum.Male,
                    Role = UserRole.Customer,
                },
                new User
                {
                    Id = new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"),
                    FirstName = "Long",
                    LastName = "Vũ",
                    Email = "vulongbinhduong@gmail.com",
                    Password = "xxx123!",
                    PhoneNumber = "0866742614",
                    DateOfBirth = new DateTime(2003, 11, 22),
                    Address = "phường Chánh Nghĩa, Tp.Thủ Dầu Một, tỉnh Bình Dương",
                    Sex = (short)SexEnum.Male,
                    Role = UserRole.ClinicOwner,
                },
                new User
                {
                    Id = new Guid("88c95c5d-219b-445e-9c3f-28d92a5d07f7"),
                    FirstName = "Huy",
                    LastName = "Quách Hoàng",
                    Email = "huyquac@gmail.com",
                    Password = "xxx123!",
                    PhoneNumber = "0332877905",
                    DateOfBirth = new DateTime(2003, 12, 12),
                    Address = "Tp.Sóc Trăng",
                    Sex = (short)SexEnum.Male,
                    Role = UserRole.ClinicOwner,
                }
            );
        }
    }
}
