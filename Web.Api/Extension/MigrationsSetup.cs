using Identity.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Extension;
public static class MigrationsSetup
{
    public static void Migrations(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var dbAppIdentity = scope.ServiceProvider.GetRequiredService<IdentityDataContext>();
            dbAppIdentity.Database.Migrate();
        }
    }
}
