using RequestOrder.API;
using RequestOrder.Appliction;
using RequestOrder.Infrastructure;
using RequestOrder.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// add services to container
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.Run();
