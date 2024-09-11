using Identity.Application.Interfaces.ServicesIdentity;
using Identity.Infraestrutura.Context;
using Identity.Infraestrutura.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.IoC;
public static class NativeInjectorConfig
{
    public static void RegistraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDataContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Connection"))
        );

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddControllers();
    }
}
