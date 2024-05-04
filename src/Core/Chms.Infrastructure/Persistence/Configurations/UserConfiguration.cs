using Kpo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chms.Infrastructure.Persistence.Configurations
{
     public class UserConfiguration : IEntityTypeConfiguration<UserMetaInfo>
    {
        public void Configure(EntityTypeBuilder<UserMetaInfo> builder)
        {
            builder.ToTable("user_metadata");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.UserMetaData);
            builder.HasIndex(e => e.UserId, "idxUserId");
        }
    }
}