using Backend.DAL.Databases.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases
{
    public static class DenticareDataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed data for area
            modelBuilder.SeedAreas();

            // Seed data for user
            modelBuilder.SeedUsers();
            
            // Seed data for clinic
            modelBuilder.SeedClinics();

            // Seed data for clinic service
            modelBuilder.SeedServices();
            
            // Seed clinic feedback
            modelBuilder.SeedClinicFeedback();
            
            // Seed certificate
            modelBuilder.SeedCertificate();

            // Seed dentists
            modelBuilder.SeedDentist();
        }
    }
}
