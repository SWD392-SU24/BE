using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class ClinicFeedbackTypeConfiguration : IEntityTypeConfiguration<ClinicFeedback>
    {
        public void Configure(EntityTypeBuilder<ClinicFeedback> builder)
        {
            builder.HasOne(x => x.Customer)
                .WithMany(y => y.ClinicFeedbacks)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Clinic)
                .WithMany(y => y.ClinicFeedbacks)
                .HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
