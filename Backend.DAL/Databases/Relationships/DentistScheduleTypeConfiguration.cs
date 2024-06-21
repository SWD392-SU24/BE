using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class DentistScheduleTypeConfiguration : IEntityTypeConfiguration<DentistSchedule>
    {
        public void Configure(EntityTypeBuilder<DentistSchedule> builder)
        {
            builder.HasKey(ds => new { ds.ScheduleId, ds.DentistId });

            builder.HasOne(x => x.Dentist)
                .WithMany(y => y.DentistSchedules)
                .HasForeignKey(x => x.DentistId);
        }
    }
}
