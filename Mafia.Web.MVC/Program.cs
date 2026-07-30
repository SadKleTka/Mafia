using Service.Common.ServiceInjector;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddTheSystem(builder.Configuration);

var app = builder.Build();

app.MapControllers();
app.Run();
