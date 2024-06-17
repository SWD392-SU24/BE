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
                    ClinicName = "Columbia Asia Saigon International Clinic",
                    Address = "08 Alexandre de Rhodes St., Ben Nghe Ward, District 1, Ho Chi Minh City",
                    LicenseNumber = "HCM0001",
                    OwnerId = new Guid("4d219f08-6205-4ded-bc09-4c148902fb35"),
                    NumberOfEmployees = 150,
                    PhoneNumber = "02838238888",
                    AreaId = 1,
                    ClinicState = 1
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
                    AreaId = 1,
                    ClinicState = 1
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
                    AreaId = 1,
                    ClinicState = 1
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
                    AreaId = 2,
                    ClinicState = 1
                }
            );
        }
    }
}
