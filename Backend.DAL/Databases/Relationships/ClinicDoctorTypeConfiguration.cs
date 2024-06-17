using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class ClinicDoctorTypeConfiguration : IEntityTypeConfiguration<ClinicDentist>
    {
        public void Configure(EntityTypeBuilder<ClinicDentist> builder)
        {
            builder.HasOne(x => x.Clinic)
                .WithMany(y => y.ClinicDentists)
                .HasForeignKey(x => x.ClinicId);

            builder.HasOne(x => x.Dentist)
                .WithMany(y => y.ClinicDentists)
                .HasForeignKey(x => x.DentistId);
            
        }
    }
}
