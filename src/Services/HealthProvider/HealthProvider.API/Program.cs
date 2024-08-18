var builder = WebApplication.CreateBuilder(args);

// add services to container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
//--------------------------

var app = builder.Build();

// configure the http request pipeline
app.MapCarter(); // router mapper for classes implementating icartermodule interface 

//--------------------------

app.Run();
