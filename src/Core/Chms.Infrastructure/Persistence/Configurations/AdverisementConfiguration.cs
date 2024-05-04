using Kpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Chms.Infrastructure.Persistence.Configurations
{

    namespace Chms.Infrastructure.Persistence.Configurations
    {
        public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
        {
            public void Configure(EntityTypeBuilder<Advertisement> builder)
            {
                builder.ToTable("advertisements");
                builder.HasKey(t => t.Id);
                builder.Property(t => t.Title).IsRequired().HasMaxLength(255);
            }
        }
    }
}
