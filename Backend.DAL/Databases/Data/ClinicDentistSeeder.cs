using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases.Data
{
    public static class ClinicDentistSeeder
    {
        public static void SeedClinicDentists(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicDentist>().HasData(
                new ClinicDentist
                {
                    Id = 1,
                    ClinicId = 1,
                    DentistId = new Guid("6b4deeed-b92a-4b77-9977-5b74d9176f5a")
                },
                new ClinicDentist
                {
                    Id = 2,
                    ClinicId = 1,
                    DentistId = new Guid("504a1a7c-36f5-46f9-95f4-b56877a648f6")
                },
                new ClinicDentist
                {
                    Id = 3,
                    ClinicId = 1,
                    DentistId = new Guid("0666d393-5502-4056-a2d4-b5433fa5d989")
                },
                new ClinicDentist
                {
                    Id = 4,
                    ClinicId = 1,
                    DentistId = new Guid("fe72d820-913a-4a4e-afbc-e73961527cfd")
                },
                new ClinicDentist
                {
                    Id = 6,
                    ClinicId = 1,
                    DentistId = new Guid("f2953e88-904a-4732-837a-a74d52452ace")
                },
                new ClinicDentist
                {
                    Id = 7,
                    ClinicId = 1,
                    DentistId = new Guid("9b22dab5-ba64-423c-8674-82af668a76cb")
                },
                new ClinicDentist
                {
                    Id = 8,
                    ClinicId = 1,
                    DentistId = new Guid("73117ab0-d927-495a-b5f1-231e50b822f4")
                },
                new ClinicDentist
                {
                    Id = 9,
                    ClinicId = 2,
                    DentistId = new Guid("fb53bc7f-7b65-4fa5-a0ba-5f789fd95be1")
                },
                new ClinicDentist
                {
                    Id = 10,
                    ClinicId = 2,
                    DentistId = new Guid("7e9ce7d7-572b-4b9c-addd-4501ecefebb7")
                },
                new ClinicDentist
                {
                    Id = 11,
                    ClinicId = 2,
                    DentistId = new Guid("013e1f35-9ab6-4bea-959b-96cec668239e")
                },
                new ClinicDentist
                {
                    Id = 12,
                    ClinicId = 3,
                    DentistId = new Guid("8b6c2e20-3b42-4464-855f-598f7971e79f")
                },
                new ClinicDentist
                {
                    Id = 13,
                    ClinicId = 3,
                    DentistId = new Guid("013e1f35-9ab6-4bea-959b-96cec668239e")
                }
            );
        }
    }
}
