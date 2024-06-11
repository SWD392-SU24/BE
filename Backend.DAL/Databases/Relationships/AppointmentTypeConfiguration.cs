using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class AppointmentTypeConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasOne(x => x.Customer)
                .WithMany(y => y.Appointments)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.TreatmentDetail)
                .WithOne(y => y.Appointment)
                .HasPrincipalKey<TreatmentDetail>(x => x.AppointmentId);
        }
    }
}
