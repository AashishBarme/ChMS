using Kpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Chms.Infrastructure.Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("posts");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Url).IsRequired().HasMaxLength(255);
            builder.Property(t => t.MetaTitle).IsRequired().HasMaxLength(255);
            builder.Property(t => t.MetaDescription).IsRequired().HasMaxLength(255);
            builder.Property(t => t.PostImage).HasMaxLength(255);
            builder.Property(t => t.CreatedBy).IsRequired();
            builder.Property(t => t.CreatedDate).IsRequired();
            builder.Property(t => t.PostStatus).IsRequired();
            builder.Property(t => t.Content).HasColumnType("text");
            builder.Property(t => t.PostImageSource).HasMaxLength(255);
            builder.HasIndex(t => t.CategoryId);
            builder.HasIndex(t =>t.SourceId );
            builder.Property(t => t.PostImageCaption).HasMaxLength(255);
        }
    }

        public class PostAdvertisementConfiguration : IEntityTypeConfiguration<PostAdvertisement>
    {
        public void Configure(EntityTypeBuilder<PostAdvertisement> builder)
        {
            builder.ToTable("post_advertisements");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Content).HasColumnType("text");
            builder.Property(t => t.PostId).IsRequired();
            builder.Property(t => t.AdvertisementId).IsRequired();
            
            
        }
    }

    public class PostContentImagesConfiguration : IEntityTypeConfiguration<PostContentImage>
    {
        public void Configure(EntityTypeBuilder<PostContentImage> builder)
        {
            builder.ToTable("post_content_images");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.PostId).IsRequired();
            builder.Property(t => t.ImageSource).HasMaxLength(255);
        }
    }


    public class  LinkedProjectDataConfiguration : IEntityTypeConfiguration<LinkedProjectData>
    {
        public void Configure(EntityTypeBuilder<LinkedProjectData> builder)
        {
            builder.ToTable("linked_project_data");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).HasMaxLength(255).IsRequired();
            builder.Property(t => t.Url).HasMaxLength(255).IsRequired();
            builder.Property(t => t.WebsiteUrl).HasMaxLength(255).IsRequired();
        }
    }
}