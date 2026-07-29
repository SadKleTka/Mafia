using DataManager.DataContract;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDataBase(connectionString);


var app = builder.Build();

app.Run();
