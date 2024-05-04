using System;
using Kpo.Domain.Common.Enums;
using Kpo.Domain.Entities;
using Chms.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chms.Infrastructure.Persistence
{
    public class KpoDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "developeradmin", Email = "administrator@localhost",UserGroup=UserGroup.Admin };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Developer@123");
            }
        }

        public static void SeedSampleDataAsync(KpoDbContext context)
        {



        }


        public static async Task SeedDefaultConfigurationAsync(KpoDbContext context)
        {
            if (!context.Configs.Any())
            {
                List<MenuDefaultValueVm> menuDefaultValue = new();
                menuDefaultValue.Add(new MenuDefaultValueVm{ Title = "Home", Slug = "/"});
                menuDefaultValue.Add(new MenuDefaultValueVm {Title = "Terms and Conditions", Slug = "/terms-and-conditions"});
                string defaultMenu = JsonSerializer.Serialize(menuDefaultValue);
                List<Config> configs = new List<Config> { 
                new Config {Key="default_user", Value="1", Group="user"},
                
                new Config {Key="default_category", Value="1", Group="category"},
                new Config {Key="theme_trending_category", Value="1", Group="theme"},
                new Config {Key="theme_grid_first_category", Value="1", Group="theme"},
                new Config {Key="theme_grid_second_category", Value="1", Group="theme"},
                
                new Config { Key="menu",Value=$"{defaultMenu}", Group="menu" },
                new Config { Key="footer_menu",Value=$"{defaultMenu}", Group="menu" },

                new Config { Key="header_script",Value=$@"<!--HS-->" , Group="script"},
                new Config { Key="footer_script", Value="", Group="script"},

                new Config {Key="website_title", Value="", Group="home"},
                new Config {Key = "website_url", Value="", Group="home"},
                new Config{Key="website_analytics_id", Value="", Group="home"},
                new Config {Key="homepage_meta_title", Value="", Group="home"},
                new Config {Key="homepage_meta_desc", Value="", Group="home"},
                new Config {Key="admin_email", Value="", Group="home"},
                //TODO: replace with appsetting value
                new Config{Key="cms_data_config",Value="" ,Group="CMS"},
                new Config{Key="show_post_image", Value="true", Group="CMS"}
            };

                context.Configs.AddRange(configs);
                await context.SaveChangesAsync();
            }
               

            
            if (!context.Advertisements.Any())
            {
                List<Advertisement> ads = new List<Advertisement>
                {
                    new Advertisement{ Title ="below-header-top",Position="below-header-top",ActiveStatus=ActiveStatus.Active,AdvertimentType=AdvertimentTypes.Desktop,Content="testing topic below header top"},
                    new Advertisement{ Title="post-block-1", Position="post-block-1", ActiveStatus=ActiveStatus.Active, AdvertimentType=AdvertimentTypes.Desktop,
                                    Content="post-block-1 ads"},
                    new Advertisement{ Title="post-block-2", Position="post-block-2", ActiveStatus=ActiveStatus.Active, AdvertimentType=AdvertimentTypes.Desktop,
                                        Content=" post-block-2 ads"}
                };
                context.Advertisements.AddRange(ads);

                await context.SaveChangesAsync();
            }

            if(!context.Categories.Any())
            {
                Category category = new()
                {
                    Title = "Uncategorized",
                    Slug = "uncategorized",
                    MetaTitle = "Uncategorized",
                    MetaDescription = "Uncategorized",
                    ActiveStatus = ActiveStatus.Active,
                    CreatedDate = DateTime.Now
                }; 
                context.Categories.Add(category);
                await context.SaveChangesAsync();
            }
            
          
        }

    }

    public class MenuDefaultValueVm
    {
        public string Title  {get; set;}
        public string Slug {get; set;}
    }
}
