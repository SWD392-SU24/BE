using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class AppointmentServiceTypeConfiguration : IEntityTypeConfiguration<AppointmentService>
    {
        public void Configure(EntityTypeBuilder<AppointmentService> builder)
        {
            builder.HasOne(x => x.Service)
                .WithMany(y => y.AppointmentServices)
                .HasForeignKey(x => x.ServiceId);

            builder.HasOne(x => x.Appointment)
                .WithMany(y => y.AppointmentServices)
                .HasForeignKey(x => x.AppointmentId);
        }
    }
}
