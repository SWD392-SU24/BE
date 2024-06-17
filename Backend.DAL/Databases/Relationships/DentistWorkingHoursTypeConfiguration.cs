using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class DentistWorkingHoursTypeConfiguration : IEntityTypeConfiguration<DentistWorkingHours>
    {
        public void Configure(EntityTypeBuilder<DentistWorkingHours> builder)
        {
            builder.HasOne(x => x.DentistSchedule)
                .WithMany(y => y.DentistWorkingHours)
                .HasForeignKey(x => x.ScheduleId);
        }
    }
}
