using Microsoft.EntityFrameworkCore;
using Partner.GRPC.Data;
using Partner.GRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<PartnerContext>(opts =>
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMigration(); // do first so data (DataMigrationExtension) migration occurs first in the pipeline 
app.MapGrpcService<GreeterService>();
app.MapGrpcService<ShipperService>();
app.MapGrpcService<LabService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
