namespace RequestOrder.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        // services.AddCarter();

        return services;
    }

    public static WebApplication UseServices(this  WebApplication app)
    {
        // app.MapCarter();

        return app;
    }
}