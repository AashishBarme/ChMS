using Kpo.Application.Common.Interface;
using Kpo.Domain.Entities;
using Chms.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;


namespace Chms.Infrastructure.Persistence
{
    public partial class KpoDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>, IKpoDbContext
    {

        public KpoDbContext(DbContextOptions<KpoDbContext> options)
            : base(options)
        {
        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostBlock> PostBlocks { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Contact> Contacts {get; set;}
        public DbSet<Source> Sources {get; set;}
        public DbSet<PostSource> PostSources {get; set;}
        public DbSet<SocialMediaScheduler> SocialMediaSchedulers {get;set;}
        public DbSet<SourceYtTopicCategory> SourceYtTopicCategories {get; set;}
        public DbSet<YtTopicCategory> YtTopicCategories {get; set;}
        public DbSet<SourceDetails> SourceDetails { get; set; }

        public DbSet<PostAdvertisement> PostAdvertisements {get;set;}
        public DbSet<PostContentImage> PostContentImages {get; set;}
        public DbSet<UserMetaInfo> UserMetaInfos {get; set;}
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            
            builder.Entity<ApplicationUser>().ToTable("users");
            builder.Entity<IdentityRole<long>>().ToTable("roles");
            builder.Entity<IdentityUserToken<long>>().ToTable("user_tokens");
            builder.Entity<IdentityUserRole<long>>().ToTable("user_roles");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("role_claims");
            builder.Entity<IdentityUserClaim<long>>().ToTable("user_claims");
            builder.Entity<IdentityUserLogin<long>>().ToTable("user_logins");
        }


    }
}
