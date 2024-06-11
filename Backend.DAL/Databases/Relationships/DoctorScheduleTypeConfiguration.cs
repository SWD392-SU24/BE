using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class DoctorScheduleTypeConfiguration : IEntityTypeConfiguration<DoctorSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
        {
            builder.HasOne(x => x.Doctor)
                .WithMany(y => y.DoctorSchedules)
                .HasForeignKey(x => x.DoctorId);
        }
    }
}
