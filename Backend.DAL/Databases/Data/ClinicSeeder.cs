using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases.Data
{
    public static class ClinicSeeder
    {
        public static void SeedClinics(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinic>().HasData(
                new Clinic
                {
                    Id = 1,
                    ClinicName = "Phòng khám Quốc tế Columbia Asia Sài Gòn",
                    Address = "08 Đường Alexandre de Rhodes, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh",
                    LicenseNumber = "HCM0001",
                    OwnerId = new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"),
                    EmployeeSize = 150,
                    PhoneNumber = "02838238888",
                    AreaId = 2,
                    ClinicState = 2
                },
                new Clinic
                {
                    Id = 2,
                    ClinicName = "Raffles Medical Thành phố Hồ Chí Minh",
                    Address = "285B Điện Biên Phủ, Phường Võ Thị Sáu, Quận 3, Thành phố Hồ Chí Minh",
                    LicenseNumber = "951JJPX15F",
                    OwnerId = new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"),
                    EmployeeSize = 200,
                    PhoneNumber = "02838240777",
                    AreaId = 2,
                    ClinicState = 2
                },
                new Clinic
                {
                    Id = 3,
                    ClinicName = "Trung tâm Y tế Quốc tế (CMI)",
                    Address = "30 Phạm Ngọc Thạch, Phường Võ Thị Sáu, Quận 3, Thành phố Hồ Chí Minh",
                    LicenseNumber = "HVAB7N3OLG",
                    OwnerId = new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"),
                    EmployeeSize = 100,
                    PhoneNumber = "02838272366",
                    AreaId = 2,
                    ClinicState = 2
                },
                new Clinic
                {
                    Id = 4,
                    ClinicName = "Phòng khám Đô thị Bình Dương",
                    Address = "Block 8, Tầng trệt của SORA Gardens II, Lô C17, Đại lộ Hùng Vương, Thành phố Mới Bình Dương, Phường Hòa Phú, Thành phố Thủ Dầu Một, Tỉnh Bình Dương",
                    LicenseNumber = "Q1X7YV93UL",
                    OwnerId = new Guid("88c95c5d-219b-445e-9c3f-28d92a5d07f7"),
                    EmployeeSize = 50,
                    PhoneNumber = "02742222220",
                    AreaId = 3,
                    ClinicState = 1
                }
            );
        }
    }
}
