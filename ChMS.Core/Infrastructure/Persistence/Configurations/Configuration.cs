using ChMS.Core.Application.Families;
using ChMS.Core.Application.Members;
using ChMS.Core.Application.MembFamilyRelation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChMS.Core.Infrastructure.Persistence.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("members");
            builder.Property(t => t.FirstName).HasMaxLength(255).IsRequired();
            builder.Property(t => t.LastName).HasMaxLength(255).IsRequired();
            builder.Property(t => t.Gender).HasMaxLength(10).IsRequired();
            builder.Property(t => t.BirthDate).HasMaxLength(50).IsRequired();
            builder.Property(t => t.PhoneNumber).HasMaxLength(50).IsRequired();
            builder.Property(t => t.CreatedBy).IsRequired();
            builder.Property(t => t.CreatedDate).HasColumnType("datetime");
            builder.Property(t => t.UpdateDate).HasColumnType("datetime");
            builder.Property(t => t.Email).HasColumnType("varchar");
            builder.Property(t => t.SecondaryPhoneNumber).HasColumnType("varchar");
            builder.Property(t => t.Occupation).HasColumnType("varchar");
            builder.Property(t => t.Photo).HasColumnType("varchar");
            builder.Property(t => t.PermanentAddress).HasColumnType("varchar");
            builder.Property(t => t.TemporaryAddress).HasColumnType("varchar");
        }
    }

    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("families");
            builder.Property(t => t.SurName).HasColumnType("varchar");
            builder.Property(t => t.PermanentAddress).HasColumnType("varchar");
            builder.Property(t => t.TemporaryAddress).HasColumnType("varchar");
        }
    }

    public class MemberFamilyRelationConfiguration: IEntityTypeConfiguration<MemberFamilyRelation>
    {
        public void Configure(EntityTypeBuilder<MemberFamilyRelation> builder)
        {
            builder.HasKey(t=> t.Id);
            builder.ToTable("memberfamilyrelations");
        }
    }

    // public class GroupsConfiguration : IEntityTypeConfiguration<Family>
    // {
    //     public void Configure(EntityTypeBuilder<Family> builder)
    //     {
    //         builder.HasKey(t => t.Id);
    //         builder.ToTable("")
    //     }
    // }


}
