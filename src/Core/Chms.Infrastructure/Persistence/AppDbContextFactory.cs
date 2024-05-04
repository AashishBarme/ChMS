using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
namespace Chms.Infrastructure.Persistence
{
    public class KpoDbContextFactory : IDesignTimeDbContextFactory<KpoDbContext>
    {
        public KpoDbContext CreateDbContext(string[] args)
        {
            var serverVersion = new Version(10, 1, 47);
            var optionsBuilder = new DbContextOptionsBuilder<KpoDbContext>();
            var cs = "server=localhost;user=admin;password=admin;database=kpo_frontend_cms;CharSet=utf8;";
            optionsBuilder.UseMySql(cs, new MySqlServerVersion(serverVersion));

            return new KpoDbContext(optionsBuilder.Options);
        }



        //private IConfigurationRoot Settings()
        //{
        //    var configurationBuilder = new ConfigurationBuilder();
        //    //Add default configuration fille
        //    configurationBuilder.AddJsonFile("dbsettings.json", optional: false);
        //  return configurationBuilder.Build();

        //}

    }
}
