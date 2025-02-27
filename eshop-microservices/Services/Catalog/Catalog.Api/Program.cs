using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);


System.Reflection.Assembly assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opt => opt.Connection(builder.Configuration.GetConnectionString("Database")!)
).UseLightweightSessions();



var app = builder.Build();

app.MapCarter();
app.Run();
