using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class TreatmentDetailTypeConfiguration : IEntityTypeConfiguration<TreatmentDetail>
    {
        public void Configure(EntityTypeBuilder<TreatmentDetail> builder)
        {
            builder.HasIndex(x => x.AppointmentId)
                .IsUnique();
        }
    }
}
