using RequestOrder.API;
using RequestOrder.Appliction;
using RequestOrder.Infrastructure;
using RequestOrder.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// add services to container
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.Run();
