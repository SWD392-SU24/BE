using Backend.BO.Commons;
using Backend.BO.Constants;
using Backend.BO.Entities;
using Backend.BO.Enums;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases
{
    public static class DenticareDataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // data
            modelBuilder.Entity<Area>().HasData(
                new Area
                {
                    Id = 1,
                    AreaName = "Hà Nội"
                },
                new Area
                {
                    Id = 2,
                    AreaName = "Tp.Hồ Chí Minh"
                },
                new Area
                {
                    Id = 3,
                    AreaName = "Bình Dương"
                },
                new Area
                {
                    Id = 4,
                    AreaName = "Đồng Nai"
                }
            );

            // data for user table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "Password123!",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(1985, 1, 1),
                    Address = "123 Main St, Anytown, USA",
                    Sex = (short)SexEnum.Male,
                    Role = UserRole.Dentist,
                },
                new User
                {
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
                    FirstName = "Admin",
                    Email = "adminexample@gmail.com",
                    Password = "reallystrongpass!123",
                    Role = UserRole.SystemAdmin,
                },
                new User
                {
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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
            
            // data for clinic 
            modelBuilder.Entity<Clinic>().HasData(
                new Clinic
                {
                    Id = 1,
                    ClinicName = "Columbia Asia Saigon International Clinic",
                    Address = "08 Alexandre de Rhodes St., Ben Nghe Ward, District 1, Ho Chi Minh City",
                    LicenseNumber = "HCM0001",
                    OwnerId = new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"),
                    NumberOfEmployees = 150,
                    PhoneNumber = "02838238888",
                    AreaId = 1
                },
                new Clinic
                {
                    Id = 2,
                    ClinicName = "Raffles Medical Ho Chi Minh",
                    Address = "285B Dien Bien Phu, Vo Thi Sau Ward, District 3, Ho Chi Minh City",
                    LicenseNumber = "HCM0002",
                    OwnerId = new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"),
                    NumberOfEmployees = 200,
                    PhoneNumber = "02838240777",
                    AreaId = 1
                },
                new Clinic
                {
                    Id = 3,
                    ClinicName = "Centre Médical International (CMI)",
                    Address = "30 Pham Ngoc Thach, Ward Vo Thi Sau, District 3, Ho Chi Minh City",
                    LicenseNumber = "HCM0003",
                    OwnerId = new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"),
                    NumberOfEmployees = 100,
                    PhoneNumber = "02838272366",
                    AreaId = 1
                },
                new Clinic
                {
                    Id = 4,
                    ClinicName = "Binh Duong Urban Clinic",
                    Address = "Block 8, Ground floor of SORA Gardens II, Lot C17, Hung Vuong Boulevard, Binh Duong New City, Hoa Phu Ward, Thu Dau Mot City, Binh Duong Province",
                    LicenseNumber = "BDU12345",
                    OwnerId = new Guid("88c95c5d-219b-445e-9c3f-28d92a5d07f7"),
                    NumberOfEmployees = 50,
                    PhoneNumber = "02742222220",
                    AreaId = 2
                }
            );
        }
    }
}
