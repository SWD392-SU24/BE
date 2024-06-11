using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class ClinicDoctorTypeConfiguration : IEntityTypeConfiguration<ClinicDoctor>
    {
        public void Configure(EntityTypeBuilder<ClinicDoctor> builder)
        {
            builder.HasOne(x => x.Clinic)
                .WithMany(y => y.ClinicDoctors)
                .HasForeignKey(x => x.ClinicId);

            builder.HasOne(x => x.Doctor)
                .WithMany(y => y.ClinicDoctors)
                .HasForeignKey(x => x.DoctorId);
        }
    }
}
