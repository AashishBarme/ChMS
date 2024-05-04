using Kpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Chms.Infrastructure.Persistence.Configurations
{
    public class PostBlocksConfiguration : IEntityTypeConfiguration<PostBlock>
    {
        public void Configure(EntityTypeBuilder<PostBlock> builder)
        {
            builder.ToTable("post_blocks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Url).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Content).HasColumnType("text");
            builder.Property(t => t.Image).HasMaxLength(255);
            builder.Property(t => t.ContentEmbed).HasColumnType("text");
        }
    }
}