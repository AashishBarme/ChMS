using Kpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chms.Infrastructure.Persistence.Configurations
{

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("categories");
            builder.Property(t => t.Title).HasMaxLength(250).IsRequired();
            builder.Property(t => t.Slug).HasMaxLength(250).IsRequired();
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(t => t.UpdatedDate).HasColumnType("datetime");
            builder.Property(t => t.MetaTitle).HasMaxLength(250).IsRequired();
            builder.Property(t => t.MetaDescription).HasMaxLength(250).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(255);
            builder.Property(t => t.SourceUrls).HasColumnType("text");
            builder.Property(t => t.SitemapTypes);
        }
    }
}