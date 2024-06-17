using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases.Data
{
    public static class ClinicFeedbackSeeder
    {
        public static void SeedClinicFeedback(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicFeedback>().HasData(
                new ClinicFeedback()
                {
                    Id = 1,
                    ClinicId = 1,
                    CustomerId = new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"),
                    FeedbackDate = DateTime.Now,
                    FeedbackDescription = string.Empty,
                    Rating = 1,
                },
                new ClinicFeedback()
                {
                    Id = 2,
                    ClinicId = 2,
                    CustomerId = new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"),
                    FeedbackDate = new DateTime(2024, 4, 22),
                    FeedbackDescription = string.Empty,
                    Rating = 3
                },
                new ClinicFeedback()
                {
                    Id = 3,
                    ClinicId = 3,
                    CustomerId = new Guid("455565de-ce04-45b6-8183-1a1f9d414a93"),
                    FeedbackDate = new DateTime(2024, 3, 22),
                    FeedbackDescription = string.Empty,
                    Rating = 4
                }
            );
        }
    }
}
