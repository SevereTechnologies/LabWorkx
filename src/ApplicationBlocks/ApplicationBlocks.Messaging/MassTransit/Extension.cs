using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationBlocks.Messaging.MassTransit;

public static class Extension
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
    {
        // Use MassTransit function to setup MassTransic in .NET Collections Consumer communications
        services.AddMassTransit(config =>
        {
            // set naming convention for readability
            config.SetKebabCaseEndpointNameFormatter();

            // check this since this library will be used by both consumer (RequestOrder service) and provider.
            // if proivded then it will automatically discover and register the consumers/subscribers
            // otherwise it's the Publisher assembly is passed as null.
            if (assembly != null)
            {
                config.AddConsumers(assembly);
            }

            // configure the use RabbitMQ as the transport
            config.UsingRabbitMq((context, configurator) =>
            {
                // configure the host using the information from AppSettings.json file
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                {
                    host.Username(configuration["MessageBroker.UserName"]!);
                    host.Password(configuration["MessageBroker.Password"]!);
                });

                // start the configuration
                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
