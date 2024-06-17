using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.Databases.Data
{
    public static class AreaSeeder
    {
        public static void SeedAreas(this ModelBuilder modelBuilder)
        {
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
        }
    }
}
