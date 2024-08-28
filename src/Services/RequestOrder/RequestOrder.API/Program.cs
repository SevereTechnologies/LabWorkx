using RequestOrder.API;
using RequestOrder.Appliction;
using RequestOrder.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// add services to container
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddWebApiServices();

var app = builder.Build();

app.Run();
