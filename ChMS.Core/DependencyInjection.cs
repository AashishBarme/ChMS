using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChMS.Core.Application.Members;
using ChMS.Core.Infrastructure.Identity;
using ChMS.Core.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ChMS.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = new JwtConfig(configuration["Jwt:Key"], configuration["Jwt:Issuer"]);
            JwtTokenService tokenService = new JwtTokenService(jwtConfig);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Issuer,
                    IssuerSigningKey = tokenService.GetSymmetricSecurityKey()
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddSingleton(tokenService);


            return services;
        }

        public static void AddDbContextAndIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChMSDbContext>(option =>
            {
                var serverVersion = new Version("8.0.23");
                option.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(serverVersion));
                //option.LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            }).AddIdentity<ApplicationUser, IdentityRole<long>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Lockout.AllowedForNewUsers = false;
            }).AddSignInManager()
              .AddDefaultTokenProviders()
              .AddEntityFrameworkStores<ChMSDbContext>();
        }
    }
}
