using UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTheSystem(builder.Configuration);

var app = builder.Build();

app.Run();
