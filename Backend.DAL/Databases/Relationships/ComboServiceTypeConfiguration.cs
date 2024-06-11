using Backend.BO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.DAL.Databases.Relationships
{
    public class ComboServiceTypeConfiguration : IEntityTypeConfiguration<ComboService>
    {
        public void Configure(EntityTypeBuilder<ComboService> builder)
        {
            builder.HasOne(x => x.Combo)
                .WithMany(y => y.ComboServices)
                .HasForeignKey(x => x.ComboId);

            builder.HasOne(x => x.Service)
                .WithMany(y => y.ComboServices)
                .HasForeignKey(x => x.ServiceId);
        }
    }
}
