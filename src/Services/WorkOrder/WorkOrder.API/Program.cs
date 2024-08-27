using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Partner.GRPC;
using WorkOrder.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Application Services
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

//Data Services
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<WorkItem>().Identity(x => x.RequestId);
}).UseLightweightSessions();

builder.Services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
builder.Services.Decorate<IWorkOrderRepository, RedisCacheWorkOrderRepository>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

//gRPC Services
builder.Services.AddGrpcClient<LabProtoService.LabProtoServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["GrpcSettings:LabUrl"]!);
})
.ConfigurePrimaryHttpMessageHandler(() => // TEMPORARY - ENVIRONMENT ONLY, bypass certificate in docker service image
{
    var handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback =
        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };

    return handler;
});

builder.Services.AddGrpcClient<ShipperProtoServie.ShipperProtoServieClient>(options =>
{
    options.Address = new Uri(builder.Configuration["GrpcSettings:ShipperUrl"]!);
})
.ConfigurePrimaryHttpMessageHandler(() => // TEMPORARY - DEV ENVIRONMENT ONLY, bypass certificate in docker service image
{
    var handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback =
        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };

    return handler;
});

//Cross-Cutting Services
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!)
    .AddRedis(builder.Configuration.GetConnectionString("Redis")!);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

// Run the Application
app.Run();
