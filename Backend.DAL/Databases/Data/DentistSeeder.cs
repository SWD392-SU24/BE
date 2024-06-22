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
                },
                new Dentist
                {
                    Id = new Guid("fe72d820-913a-4a4e-afbc-e73961527cfd"),
                    FirstName = "Hoàng",
                    LastName = "Anh",
                    Email = "hoanganh5678@gmail.com",
                    Password = "abcde@123",
                    PhoneNumber = "0987654321",
                    DateOfBirth = new DateTime(1990, 05, 25),
                    Sex = (short)SexEnum.Male
                },
                new Dentist
                {
                    Id = new Guid("f2953e88-904a-4732-837a-a74d52452ace"),
                    FirstName = "Linh",
                    LastName = "Chi",
                    Email = "linhchi987@gmail.com",
                    Password = "qwert@567",
                    PhoneNumber = "0975123456",
                    DateOfBirth = new DateTime(1985, 11, 18),
                    Sex = (short)SexEnum.Female
                },
                new Dentist
                {
                    Id = new Guid("9b22dab5-ba64-423c-8674-82af668a76cb"),
                    FirstName = "Trung",
                    LastName = "Nghĩa",
                    Email = "trungnghia246@gmail.com",
                    Password = "nghiatrung!321",
                    PhoneNumber = "0908765432",
                    DateOfBirth = new DateTime(1978, 07, 03),
                    Sex = (short)SexEnum.Male
                },
                new Dentist
                {
                    Id = new Guid("73117ab0-d927-495a-b5f1-231e50b822f4"),
                    FirstName = "Thu",
                    LastName = "Hà",
                    Email = "thuha135@gmail.com",
                    Password = "ha!@#$123",
                    PhoneNumber = "0932145678",
                    DateOfBirth = new DateTime(1989, 04, 15),
                    Sex = (short)SexEnum.Female
                },
                new Dentist
                {
                    Id = new Guid("fb53bc7f-7b65-4fa5-a0ba-5f789fd95be1"),
                    FirstName = "Duy",
                    LastName = "Tùng",
                    Email = "duytung753@gmail.com",
                    Password = "tungDuy@789",
                    PhoneNumber = "0945671234",
                    DateOfBirth = new DateTime(1982, 10, 20),
                    Sex = (short)SexEnum.Male
                },
                new Dentist
                {
                    Id = new Guid("7e9ce7d7-572b-4b9c-addd-4501ecefebb7"),
                    FirstName = "Mai",
                    LastName = "An",
                    Email = "maian369@gmail.com",
                    Password = "AnMai@456",
                    PhoneNumber = "0923456789",
                    DateOfBirth = new DateTime(1995, 08, 22),
                    Sex = (short)SexEnum.Female
                },
                new Dentist
                {
                    Id = new Guid("013e1f35-9ab6-4bea-959b-96cec668239e"),
                    FirstName = "Quang",
                    LastName = "Hải",
                    Email = "quanghai258@gmail.com",
                    Password = "haiQuang@789",
                    PhoneNumber = "0961234567",
                    DateOfBirth = new DateTime(1987, 12, 10),
                    Sex = (short)SexEnum.Male
                },
                new Dentist
                {
                    Id = new Guid("9deaf970-838d-48d6-87e1-b756072d16ac"),
                    FirstName = "Hương",
                    LastName = "Linh",
                    Email = "huonglinh147@gmail.com",
                    Password = "Linh@1478",
                    PhoneNumber = "0918765432",
                    DateOfBirth = new DateTime(1993, 03, 28),
                    Sex = (short)SexEnum.Female
                },
                new Dentist
                {
                    Id = new Guid("8b6c2e20-3b42-4464-855f-598f7971e79f"),
                    FirstName = "Minh",
                    LastName = "Tuấn",
                    Email = "minhtuan159@gmail.com",
                    Password = "tu@n159!",
                    PhoneNumber = "0983214567",
                    DateOfBirth = new DateTime(1980, 06, 14),
                    Sex = (short)SexEnum.Male
                }

            );
        }
    }
}
