using Kpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Chms.Infrastructure.Persistence.Configurations
{
    public class ConfigConfiguration : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable("configs");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Key).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Value).HasColumnType("text");
            builder.Property(t => t.Group).HasMaxLength(255);

        }
    }
}