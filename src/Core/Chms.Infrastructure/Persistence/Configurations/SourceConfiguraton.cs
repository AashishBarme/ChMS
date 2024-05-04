using Kpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Chms.Infrastructure.Persistence.Configurations
{
    public class SourceConfiguration : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder.ToTable("sources");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Url).IsRequired().HasMaxLength(255);
            builder.Property(t => t.SourceUrl).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Description).HasColumnType("text");
        }
    }

    public class PostSourceConfiguration : IEntityTypeConfiguration<PostSource>
    {
        public void Configure(EntityTypeBuilder<PostSource> builder)
        {
            builder.ToTable("post_sources");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.PostId).IsRequired().HasMaxLength(255);
            builder.Property(t => t.SourceId).IsRequired().HasMaxLength(255);
        }
    }
     public class SourceYtTopicCategoryConfiguration : IEntityTypeConfiguration<SourceYtTopicCategory>
    {
        public void Configure(EntityTypeBuilder<SourceYtTopicCategory> builder)
        {
            builder.ToTable("source_yt_topic_categories");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.SourceId).IsRequired().HasMaxLength(255);
            builder.Property(t => t.YtTopicCategoryId).IsRequired().HasMaxLength(255);
      
        }
    }

      public class YtTopicCategoryConfiguration : IEntityTypeConfiguration<YtTopicCategory>
        {
            public void Configure(EntityTypeBuilder<YtTopicCategory> builder)
            {
                builder.ToTable("yt_topic_categories");
                builder.HasKey(t => t.Id);
                builder.Property(t => t.Title).IsRequired().HasMaxLength(255);
                builder.Property(t => t.YoutubeReferenceId).IsRequired().HasMaxLength(255);
            }
        }

    public class SourceDetailsConfiguration : IEntityTypeConfiguration<SourceDetails>
    {
        public void Configure(EntityTypeBuilder<SourceDetails> builder)
        {
            builder.ToTable("source_details");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.SourceId).IsRequired();
            builder.Property(t => t.TotalViews).HasMaxLength(50);
            builder.Property(t => t.TotalVideos).HasMaxLength(50);
            builder.Property(t => t.Subscribers).HasMaxLength(50);
            builder.Property(t => t.Country).HasMaxLength(20);
            builder.Property(t => t.ThumbnailUrl).HasMaxLength(255);
            builder.Property(t => t.BannerUrl).HasMaxLength(255);
            builder.Property(t => t.Keywords).HasColumnType("text");
        }
    }
}