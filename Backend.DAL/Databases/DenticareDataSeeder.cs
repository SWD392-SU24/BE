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
                    FirstName = "A",
                    LastName = "Nguyễn Văn",
                    Email = "nguyen.vana@gmail.com",
                    Password = "Password123!",
                    PhoneNumber = "0987654321",
                    DateOfBirth = new DateTime(1990, 4, 15),
                    Address = "456 Lê Lợi, Hồ Chí Minh City, Vietnam",
                    Sex = (short)SexEnum.Male,
                    Role = UserRole.Dentist,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "B",
                    LastName = "Trần Thị",
                    Email = "tran.thib@example.com",
                    Password = "Password123!",
                    PhoneNumber = "0976543210",
                    DateOfBirth = new DateTime(1988, 7, 22),
                    Address = "789 Trần Hưng Đạo, Hà Nội, Vietnam",
                    Sex = (short)SexEnum.Male,
                    Role = UserRole.Dentist,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Hà",
                    LastName = "Phùng Trần Mai",
                    Email = "janetran639@gmail.com",
                    Password = "999doahoahong@",
                    PhoneNumber = "0902694265",
                    DateOfBirth = new DateTime(1987, 11, 11),
                    Address = "phường Phước Long A, Q.9, Tp.Hồ Chí Minh",
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

            // data for Service
            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    ServiceName = "Chụp Xquang CBCT",
                    Description = "Bệnh nhân sẽ được Chụp Xquang CBCT",
                    Price = 50.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 2,
                    ServiceName = "Chụp Xquang Cephalometric",
                    Description = "Bệnh nhân sẽ được Chụp Xquang Cephalometric",
                    Price = 80.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 3,
                    ServiceName = "Khám tư vấn",
                    Description = "Bệnh nhân sẽ được khám tư vấn",
                    Price = 70.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 4,
                    ServiceName = "Chụp Xquang Panorama",
                    Description = "Bệnh nhân sẽ được Chụp Xquang Panorama",
                    Price = 100.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 5,
                    ServiceName = "Máng chống ê buốt",
                    Description = "Máng chống ê buốt cho răng",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 6,
                    ServiceName = "Máng nha chu",
                    Description = "Máng dành cho bệnh nhân nha chu",
                    Price = 50.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 7,
                    ServiceName = "Lấy cao răng 2 hàm",
                    Description = "Lấy cao răng",
                    Price = 80.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 8,
                    ServiceName = "Điều trị tủy",
                    Description = "Trám răng để răng đẹp và tốt hơn",
                    Price = 70.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 9,
                    ServiceName = "Hàn thẩm mỹ",
                    Description = "Hàn thẩm mỹ cho bệnh nhân",
                    Price = 100.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 10,
                    ServiceName = "Hàn cổ răng",
                    Description = "Hàn cổ răng cho bệnh nhân",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 11,
                    ServiceName = "Hàn răng sâu",
                    Description = "Hàn răng sâu cho bệnh nhân",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 12,
                    ServiceName = "Tiểu phẫu nha chu",
                    Description = "Tiểu phẫu dành cho bệnh nhân nha chu",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 13,
                    ServiceName = "Sealant ngừa sâu răng",
                    Description = "Ngừa sâu răng cho trẻ em",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 14,
                    ServiceName = "Bôi fluoride dự phòng sâu răng",
                    Description = "Ngừa sâu răng cho trẻ em",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 15,
                    ServiceName = "Điều trị tủy răng sữa nhiều chân",
                    Description = "Điều trị tủy răng cho trẻ em",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 16,
                    ServiceName = "Điều trị tủy răng sữa 1 chân",
                    Description = "Điều trị tủy răng cho trẻ em",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 17,
                    ServiceName = "Hàn răng sữa",
                    Description = "Hàn răng sữa cho trẻ em",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 18,
                    ServiceName = "Nhổ răng sữa tê tiêm",
                    Description = "Nhổ răng tiêm thuốc tê cho trẻ em",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 19,
                    ServiceName = "Nhổ răng sữa tê bôi",
                    Description = "Nhổ răng bôi thuốc tê cho trẻ em",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 20,
                    ServiceName = "Hàm Twinblock",
                    Description = "Hàm Twinblock",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 21,
                    ServiceName = "Hàm nong",
                    Description = "Hàm nong",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 22,
                    ServiceName = "Chỉnh nha bằng khay trong suốt Invisalign",
                    Description = "Chỉnh nha bằng khay trong suốt Invisalign cho bệnh nhân",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 23,
                    ServiceName = "Chỉnh nha bằng mắc cài sứ 2 hàm",
                    Description = "Chỉnh nha bằng mắc cài sứ 2 hàm cho bệnh nhân",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 24,
                    ServiceName = "Chỉnh nha bằng mắc cài kim loại 2 hàm",
                    Description = "Chỉnh nha bằng mắc cài kim loại 2 hàm cho bệnh nhân",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 25,
                    ServiceName = "Hàm duy trì sau chỉnh nha",
                    Description = "Hàm duy trì sau chỉnh nha cho bệnh nhân",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 26,
                    ServiceName = "Cấy Implant All-on-6",
                    Description = "Implant",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 27,
                    ServiceName = "Cấy Implant All-on-4",
                    Description = "Implant",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 28,
                    ServiceName = "Cấy Implant Hàn Quốc răng hàm",
                    Description = "Implant răng hàm",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 29,
                    ServiceName = "Cấy Implant Hàn Quốc răng cửa",
                    Description = "Implant răng cửa",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 30,
                    ServiceName = "Ghép xương",
                    Description = "Ghép xương",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 31,
                    ServiceName = "Nâng xoang",
                    Description = "Nâng xoang",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 32,
                    ServiceName = "Nhổ răng khôn (răng số 8) mọc ngầm",
                    Description = "Nhổ răng khôn",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 33,
                    ServiceName = "Nhổ răng khôn (răng số 8) mọc lệch",
                    Description = "Nhổ răng khôn",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 34,
                    ServiceName = "Nhổ răng khôn (răng số 8) mọc thẳng",
                    Description = "Nhổ răng khôn",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 35,
                    ServiceName = "Nhổ chân răng",
                    Description = "Nhổ chân răng",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 36,
                    ServiceName = "Nhổ răng hàm",
                    Description = "Nhổ răng hàm",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 37,
                    ServiceName = "Nhổ răng cửa",
                    Description = "Nhổ răng cửa",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 38,
                    ServiceName = "Onlay/inlay sứ kim loại",
                    Description = "Onlay/inlay sứ kim loại",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 39,
                    ServiceName = "Hàm nhựa dẻo tháo lắp",
                    Description = "Hàm nhựa dẻo tháo lắp",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 40,
                    ServiceName = "Chụp sứ/veneer sứ Emax HT",
                    Description = "Chụp sứ/veneer sứ Emax HT",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 41,
                    ServiceName = "Chụp sứ/Veneer sứ Emax",
                    Description = "Chụp sứ/Veneer sứ Emax",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 42,
                    ServiceName = "Chụp sứ Zirconia",
                    Description = "Chụp sứ Zirconia",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 43,
                    ServiceName = "Chụp sứ Titan",
                    Description = "Chụp sứ Titan",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 44,
                    ServiceName = "Chụp sứ kim loại thường",
                    Description = "Chụp sứ kim loại thường",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 45,
                    ServiceName = "Chụp composite",
                    Description = "Chụp composite",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 46,
                    ServiceName = "Phẫu thuật tạo hình lợi",
                    Description = "Phẫu thuật tạo hình lợi",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 47,
                    ServiceName = "Hàm điều chỉnh khớp thái dương hàm",
                    Description = "Hàm điều chỉnh khớp thái dương hàm",
                    Price = 120.00,
                    ClinicId = 1
                },
                new Service
                {
                    Id = 48,
                    ServiceName = "Khám tư vấn",
                    Description = "Khám và tư vấn",
                    Price = 120.00,
                    ClinicId = 2
                },
                new Service
                {
                    Id = 49,
                    ServiceName = "Chụp Xquang",
                    Description = "Chụp Xquang",
                    Price = 120.00,
                    ClinicId = 2
                },
                new Service
                {
                    Id = 50,
                    ServiceName = "Lấy cao răng",
                    Description = "Lấy cao răng",
                    Price = 120.00,
                    ClinicId = 2
                },
                new Service
                {
                    Id = 51,
                    ServiceName = "Máng chống ê buốt",
                    Description = "Máng chống ê buốt",
                    Price = 120.00,
                    ClinicId = 2
                },
                new Service
                {
                    Id = 52,
                    ServiceName = "Khám tư vấn",
                    Description = "Khám và tư vấn",
                    Price = 120.00,
                    ClinicId = 3
                },
                new Service
                {
                    Id = 53,
                    ServiceName = "Chụp Xquang",
                    Description = "Chụp Xquang",
                    Price = 120.00,
                    ClinicId = 3
                },
                new Service
                {
                    Id = 54,
                    ServiceName = "Lấy cao răng",
                    Description = "Lấy cao răng",
                    Price = 120.00,
                    ClinicId = 3
                },
                new Service
                {
                    Id = 55,
                    ServiceName = "Máng chống ê buốt",
                    Description = "Máng chống ê buốt",
                    Price = 120.00,
                    ClinicId = 3
                },
                new Service
                {
                    Id = 56,
                    ServiceName = "Khám tư vấn",
                    Description = "Khám và tư vấn",
                    Price = 120.00,
                    ClinicId = 4
                },
                new Service
                {
                    Id = 57,
                    ServiceName = "Chụp Xquang",
                    Description = "Chụp Xquang",
                    Price = 120.00,
                    ClinicId = 4
                },
                new Service
                {
                    Id = 58,
                    ServiceName = "Lấy cao răng",
                    Description = "Lấy cao răng",
                    Price = 120.00,
                    ClinicId = 4
                },
                new Service
                {
                    Id = 59,
                    ServiceName = "Máng chống ê buốt",
                    Description = "Máng chống ê buốt",
                    Price = 120.00,
                    ClinicId = 4
                }
            );

            // data for Combo
            modelBuilder.Entity<Combo>().HasData(
                new Combo
                {
                    Id = 1,
                    ComboName = "Khám tư vấn",
                    Description = "Mục gồm các vấn đề liên quan đến Khám tư vấn"
                },
                new Combo
                {
                    Id = 2,
                    ComboName = "Nha khoa tổng quát",
                    Description = "Mục gồm các vấn đề liên quan đến Nha khoa tổng quát"
                },
                new Combo
                {
                    Id = 3,
                    ComboName = "Nha khoa trẻ em",
                    Description = "Mục gồm các vấn đề liên quan đến Nha khoa trẻ em"
                },
                new Combo
                {
                    Id = 4,
                    ComboName = "Chỉnh nha",
                    Description = "Mục gồm các vấn đề liên quan đến Chỉnh nha"
                },
                new Combo
                {
                    Id = 5,
                    ComboName = "Cấy ghép Implant",
                    Description = "Mục gồm các vấn đề liên quan đến Cấy ghép Implant"
                },
                new Combo
                {
                    Id = 6,
                    ComboName = "Nhổ răng",
                    Description = "Mục gồm các vấn đề liên quan đến Nhổ răng"
                },
                new Combo
                {
                    Id = 7,
                    ComboName = "Nha khoa thẩm mỹ",
                    Description = "Mục gồm các vấn đề liên quan đến Nha khoa thẩm mỹ"
                },
                new Combo
                {
                    Id = 8,
                    ComboName = "Khác",
                    Description = "Mục gồm các vấn đề khác ngoài các mục đã có"
                }
            );

            // data for ComboService
            modelBuilder.Entity<ComboService>().HasData(
                new ComboService
                {
                    Id = 1,
                    ServiceId = 1,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 2,
                    ServiceId = 2,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 3,
                    ServiceId = 3,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 4,
                    ServiceId = 4,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 5,
                    ServiceId = 5,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 6,
                    ServiceId = 6,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 7,
                    ServiceId = 7,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 8,
                    ServiceId = 8,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 9,
                    ServiceId = 9,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 10,
                    ServiceId = 10,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 11,
                    ServiceId = 11,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 12,
                    ServiceId = 12,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 13,
                    ServiceId = 13,
                    ComboId = 3
                },
                new ComboService
                {
                    Id = 14,
                    ServiceId = 14,
                    ComboId = 3
                },
                new ComboService
                {
                    Id = 15,
                    ServiceId = 15,
                    ComboId = 3
                },
                new ComboService
                {
                    Id = 16,
                    ServiceId = 16,
                    ComboId = 3
                },
                new ComboService
                {
                    Id = 17,
                    ServiceId = 17,
                    ComboId = 3
                },
                new ComboService
                {
                    Id = 18,
                    ServiceId = 18,
                    ComboId = 3
                },
                new ComboService
                {
                    Id = 19,
                    ServiceId = 19,
                    ComboId = 3
                },
                new ComboService
                {
                    Id = 20,
                    ServiceId = 20,
                    ComboId = 4
                },
                new ComboService
                {
                    Id = 21,
                    ServiceId = 21,
                    ComboId = 4
                },
                new ComboService
                {
                    Id = 22,
                    ServiceId = 22,
                    ComboId = 4
                },
                new ComboService
                {
                    Id = 23,
                    ServiceId = 23,
                    ComboId = 4
                },
                new ComboService
                {
                    Id = 24,
                    ServiceId = 24,
                    ComboId = 4
                },
                new ComboService
                {
                    Id = 25,
                    ServiceId = 25,
                    ComboId = 4
                },
                new ComboService
                {
                    Id = 26,
                    ServiceId = 26,
                    ComboId = 5
                },
                new ComboService
                {
                    Id = 27,
                    ServiceId = 27,
                    ComboId = 5
                },
                new ComboService
                {
                    Id = 28,
                    ServiceId = 28,
                    ComboId = 5
                },
                new ComboService
                {
                    Id = 29,
                    ServiceId = 29,
                    ComboId = 5
                },
                new ComboService
                {
                    Id = 30,
                    ServiceId = 30,
                    ComboId = 5
                },
                new ComboService
                {
                    Id = 31,
                    ServiceId = 31,
                    ComboId = 5
                },
                new ComboService
                {
                    Id = 32,
                    ServiceId = 32,
                    ComboId = 6
                },
                new ComboService
                {
                    Id = 33,
                    ServiceId = 33,
                    ComboId = 6
                },
                new ComboService
                {
                    Id = 34,
                    ServiceId = 34,
                    ComboId = 6
                },
                new ComboService
                {
                    Id = 35,
                    ServiceId = 35,
                    ComboId = 6
                },
                new ComboService
                {
                    Id = 36,
                    ServiceId = 36,
                    ComboId = 6
                },
                new ComboService
                {
                    Id = 37,
                    ServiceId = 37,
                    ComboId = 6
                },
                new ComboService
                {
                    Id = 38,
                    ServiceId = 38,
                    ComboId = 7
                },
                new ComboService
                {
                    Id = 39,
                    ServiceId = 39,
                    ComboId = 7
                },
                new ComboService
                {
                    Id = 40,
                    ServiceId = 40,
                    ComboId = 7
                },
                new ComboService
                {
                    Id = 41,
                    ServiceId = 41,
                    ComboId = 7
                },
                new ComboService
                {
                    Id = 42,
                    ServiceId = 42,
                    ComboId = 7
                },
                new ComboService
                {
                    Id = 43,
                    ServiceId = 43,
                    ComboId = 7
                },
                new ComboService
                {
                    Id = 44,
                    ServiceId = 44,
                    ComboId = 7
                },
                new ComboService
                {
                    Id = 45,
                    ServiceId = 45,
                    ComboId = 7
                },
                new ComboService
                {
                    Id = 46,
                    ServiceId = 46,
                    ComboId = 8
                },
                new ComboService
                {
                    Id = 47,
                    ServiceId = 47,
                    ComboId = 8
                },
                new ComboService
                {
                    Id = 48,
                    ServiceId = 48,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 49,
                    ServiceId = 49,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 50,
                    ServiceId = 50,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 51,
                    ServiceId = 51,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 52,
                    ServiceId = 52,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 53,
                    ServiceId = 53,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 54,
                    ServiceId = 54,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 55,
                    ServiceId = 55,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 56,
                    ServiceId = 56,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 57,
                    ServiceId = 57,
                    ComboId = 1
                },
                new ComboService
                {
                    Id = 58,
                    ServiceId = 58,
                    ComboId = 2
                },
                new ComboService
                {
                    Id = 59,
                    ServiceId = 59,
                    ComboId = 2
                }
            );
        }
    }
}
