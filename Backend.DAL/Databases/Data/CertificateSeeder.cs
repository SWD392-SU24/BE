using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases.Data
{
    public static class CertificateSeeder
    {
        public static void SeedCertificate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>().HasData(
                new Certificate
                {
                    Id = 1,
                    CertificateName = "Medical Practice License",
                    IssuedDate = DateTime.Now,
                    CertificateNumber = "CERT-001",
                    CertificateImage = "https://example.com/certificateImage.jpg",
                    DentistId = new Guid("6b4deeed-b92a-4b77-9977-5b74d9176f5a")
                },
                new Certificate
                {
                    Id = 2,
                    CertificateName = "Dental Surgery Certification",
                    IssuedDate = new DateTime(2022, 8, 20),
                    CertificateNumber = "CERT-002",
                    CertificateImage = "https://example.com/certificateImage2.jpg",
                    DentistId = new Guid("73117ab0-d927-495a-b5f1-231e50b822f4")
                },
                new Certificate
                {
                    Id = 3,
                    CertificateName = "Emergency Medicine Training",
                    IssuedDate = new DateTime(2024, 3, 10),
                    CertificateNumber = "CERT-003",
                    CertificateImage = "https://example.com/certificateImage3.jpg",
                    DentistId = new Guid("0666d393-5502-4056-a2d4-b5433fa5d989")
                },
                new Certificate
                {
                    Id = 4,
                    CertificateName = "Giấy phép Hành nghề Y tế",
                    IssuedDate = DateTime.Parse("2023-05-10"),
                    ExpiredDate = DateTime.Parse("2025-05-10"),
                    CertificateNumber = "FT5B5KAR1H",
                    CertificateImage = "https://example.com/certificateImage1.jpg",
                    DentistId = new Guid("504a1a7c-36f5-46f9-95f4-b56877a648f6")
                },
                new Certificate
                {
                    Id = 5,
                    CertificateName = "Bằng cấp Nha khoa",
                    IssuedDate = DateTime.Parse("2022-12-15"),
                    ExpiredDate = DateTime.Parse("2024-12-15"),
                    CertificateNumber = "RW3KE4QEC2",
                    CertificateImage = string.Empty,
                    DentistId = new Guid("0666d393-5502-4056-a2d4-b5433fa5d989")
                },
                new Certificate
                {
                    Id = 6,
                    CertificateName = "Chứng chỉ Phẫu thuật",
                    IssuedDate = DateTime.Parse("2023-08-20"),
                    ExpiredDate = DateTime.Parse("2025-08-20"),
                    CertificateNumber = "KNBN151OV2",
                    CertificateImage = string.Empty,
                    DentistId = new Guid("f2953e88-904a-4732-837a-a74d52452ace")
                },
                new Certificate
                {
                    Id = 7,
                    CertificateName = "Văn bằng Y học",
                    IssuedDate = DateTime.Parse("2022-10-05"),
                    ExpiredDate = DateTime.Parse("2024-10-05"),
                    CertificateNumber = "OSXN50N1TW",
                    CertificateImage = string.Empty,
                    DentistId = new Guid("fe72d820-913a-4a4e-afbc-e73961527cfd")
                }
            );
        }
    }
}
