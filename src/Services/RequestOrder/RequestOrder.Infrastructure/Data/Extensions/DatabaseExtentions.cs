using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RequestOrder.Infrastructure.Data.Extensions;

public static class DatabaseExtentions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedLabAsync(context);
        await SeedShipperAsync(context);
        await SeedPatientAsync(context);
        await SeedProviderAsync(context);
        await SeedTechnicianAsync(context);
        await SeedProcedureAsync(context);
        await SeedOrderAsync(context);
    }

    private static async Task SeedLabAsync(ApplicationDbContext context)
    {
        if (!await context.Labs.AnyAsync())
        {
            await context.Labs.AddRangeAsync(SeedData.Labs);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedShipperAsync(ApplicationDbContext context)
    {
        if (!await context.Shippers.AnyAsync())
        {
            await context.Shippers.AddRangeAsync(SeedData.Shippers);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedPatientAsync(ApplicationDbContext context)
    {
        if (!await context.Patients.AnyAsync())
        {
            await context.Patients.AddRangeAsync(SeedData.Patients);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedProviderAsync(ApplicationDbContext context)
    {
        if (!await context.Providers.AnyAsync())
        {
            await context.Providers.AddRangeAsync(SeedData.Providers);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedTechnicianAsync(ApplicationDbContext context)
    {
        if (!await context.Technicians.AnyAsync())
        {
            await context.Technicians.AddRangeAsync(SeedData.Technicians);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedProcedureAsync(ApplicationDbContext context)
    {
        if (!await context.Procedures.AnyAsync())
        {
            await context.Procedures.AddRangeAsync(SeedData.Procedures);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedOrderAsync(ApplicationDbContext context)
    {
        if (!await context.Orders.AnyAsync())
        {
            await context.Orders.AddRangeAsync(SeedData.Orders);
            await context.SaveChangesAsync();
        }
    }
}
