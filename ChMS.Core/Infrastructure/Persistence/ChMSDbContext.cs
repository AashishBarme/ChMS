using ChMS.Core.Application.Members;
using ChMS.Core.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Infrastructure.Persistence
{
    public partial class ChMSDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public ChMSDbContext(DbContextOptions<ChMSDbContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
 

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

    public class ChMSDbContextFactory : IDesignTimeDbContextFactory<ChMSDbContext>
    {
        public ChMSDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChMSDbContext>();
            var serverVersion = new Version(10, 1, 47);
            var cs = "server=localhost;user=admin;password=admin;database=chms_data;CharSet=utf8;";
            optionsBuilder.UseMySql(cs, new MySqlServerVersion(serverVersion));
            return new ChMSDbContext(optionsBuilder.Options);
        }
    }
}
