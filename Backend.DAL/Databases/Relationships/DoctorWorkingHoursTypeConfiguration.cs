using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class DoctorWorkingHoursTypeConfiguration : IEntityTypeConfiguration<DoctorWorkingHours>
    {
        public void Configure(EntityTypeBuilder<DoctorWorkingHours> builder)
        {
            builder.HasOne(x => x.DoctorSchedule)
                .WithMany(y => y.DoctorWorkingHours)
                .HasForeignKey(x => x.ScheduleId);
        }
    }
}
