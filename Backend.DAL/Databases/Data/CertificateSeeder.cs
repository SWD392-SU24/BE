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
                    DentistId = new Guid("0666d393-5502-4056-a2d4-b5433fa5d989")
                },
                new Certificate
                {
                    Id = 2,
                    CertificateName = "Dental Surgery Certification",
                    IssuedDate = new DateTime(2022, 8, 20),
                    CertificateNumber = "CERT-002",
                    CertificateImage = "https://example.com/certificateImage2.jpg",
                    DentistId = new Guid("0666d393-5502-4056-a2d4-b5433fa5d989")
                },
                new Certificate
                {
                    Id = 3,
                    CertificateName = "Emergency Medicine Training",
                    IssuedDate = new DateTime(2024, 3, 10),
                    CertificateNumber = "CERT-003",
                    CertificateImage = "https://example.com/certificateImage3.jpg",
                    DentistId = new Guid("0666d393-5502-4056-a2d4-b5433fa5d989")
                }
            );
        }
    }
}
