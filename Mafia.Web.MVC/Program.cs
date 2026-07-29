var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
builder.Services.AddDataBase(connectionString);


var app = builder.Build();

app.Run();
