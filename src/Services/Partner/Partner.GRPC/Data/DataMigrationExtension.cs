using Microsoft.EntityFrameworkCore;

namespace Partner.GRPC.Data;

public static class DataMigrationExtension
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<PartnerContext>();
        dbContext.Database.MigrateAsync();

        return app;
    }
}
