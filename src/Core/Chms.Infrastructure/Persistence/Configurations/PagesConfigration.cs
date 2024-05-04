using Kpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Chms.Infrastructure.Persistence.Configurations
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("pages");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Url).IsRequired().HasMaxLength(255);
            builder.Property(t => t.MetaTitle).IsRequired().HasMaxLength(255);
            builder.Property(t => t.MetaDescription).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Content).HasColumnType("text");

        }
    }
}