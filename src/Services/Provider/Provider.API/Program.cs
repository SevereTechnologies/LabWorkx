var builder = WebApplication.CreateBuilder(args);

// add services to container
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
//--------------------------

var app = builder.Build();

// configure the http request pipeline
app.MapCarter(); // router mapper for classes implementating icartermodule interface 

app.UseExceptionHandler(options => { });
//--------------------------

app.Run();