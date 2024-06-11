using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class CertificateTypeConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasOne(x => x.Doctor)
                .WithMany(y => y.Certificates)
                .HasForeignKey(x => x.DoctorId);
        }
    }
}
