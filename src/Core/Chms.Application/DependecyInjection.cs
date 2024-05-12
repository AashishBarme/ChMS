using System.Reflection;
using Chms.Application.Common.Interface;
using Chms.Application.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chms.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLogic(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IFamilyService, FamilyService>();
        services.AddScoped<IInventoryService, InventoryService>();
        return services;
    }
}
