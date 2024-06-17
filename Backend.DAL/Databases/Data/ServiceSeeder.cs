using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases.Data
{
    public static class ServiceSeeder
    {
        public static void SeedServices(this ModelBuilder modelBuilder)
        {
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
                    ClinicId = 2
                },
                new Service
                {
                    Id = 6,
                    ServiceName = "Máng nha chu",
                    Description = "Máng dành cho bệnh nhân nha chu",
                    Price = 50.00,
                    ClinicId = 2
                },
                new Service
                {
                    Id = 7,
                    ServiceName = "Lấy cao răng 2 hàm",
                    Description = "Lấy cao răng",
                    Price = 80.00,
                    ClinicId = 2
                },
                new Service
                {
                    Id = 8,
                    ServiceName = "Điều trị tủy",
                    Description = "Trám răng để răng đẹp và tốt hơn",
                    Price = 70.00,
                    ClinicId = 2
                },
                new Service
                {
                    Id = 9,
                    ServiceName = "Hàn thẩm mỹ",
                    Description = "Hàn thẩm mỹ cho bệnh nhân",
                    Price = 100.00,
                    ClinicId = 3
                },
                new Service
                {
                    Id = 10,
                    ServiceName = "Hàn cổ răng",
                    Description = "Hàn cổ răng cho bệnh nhân",
                    Price = 120.00,
                    ClinicId = 3
                },
                new Service
                {
                    Id = 11,
                    ServiceName = "Hàn răng sâu",
                    Description = "Hàn răng sâu cho bệnh nhân",
                    Price = 120.00,
                    ClinicId = 3
                },
                new Service
                {
                    Id = 12,
                    ServiceName = "Tiểu phẫu nha chu",
                    Description = "Tiểu phẫu dành cho bệnh nhân nha chu",
                    Price = 120.00,
                    ClinicId = 3
                },
                new Service
                {
                    Id = 13,
                    ServiceName = "Sealant ngừa sâu răng",
                    Description = "Ngừa sâu răng cho trẻ em",
                    Price = 120.00,
                    ClinicId = 4
                },
                new Service
                {
                    Id = 14,
                    ServiceName = "Bôi fluoride dự phòng sâu răng",
                    Description = "Ngừa sâu răng cho trẻ em",
                    Price = 120.00,
                    ClinicId = 4
                },
                new Service
                {
                    Id = 15,
                    ServiceName = "Điều trị tủy răng sữa nhiều chân",
                    Description = "Điều trị tủy răng cho trẻ em",
                    Price = 120.00,
                    ClinicId = 4
                }
            );
        }
    }
}
