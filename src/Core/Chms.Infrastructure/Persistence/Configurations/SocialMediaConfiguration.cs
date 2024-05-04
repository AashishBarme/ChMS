using Kpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Chms.Infrastructure.Persistence.Configurations
{
    public class SocialMediaSchedulerConfiguration : IEntityTypeConfiguration<SocialMediaScheduler>
    {
        public void Configure(EntityTypeBuilder<SocialMediaScheduler> builder)
        {
            builder.ToTable("social_media_scheduler");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Url).IsRequired().HasMaxLength(255);
            builder.Property(t => t.CategoryId).IsRequired();
            builder.Property(t => t.PostedOnTwitter).HasDefaultValue(false);
            builder.HasIndex(t => t.CategoryId);
        }
    }

}