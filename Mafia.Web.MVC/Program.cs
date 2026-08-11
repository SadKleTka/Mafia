using System.Text;
using Mafia.Web.MVC.GameHub;
using Mafia.Web.MVC.MiddleWare;
using Service.Common.ServiceInjector;
using Service.Common.UserService;
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

builder.Services.AddTheSystem(builder.Configuration);
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}

app.MapHub<MafiaHub>("/hub/lobby");
app.UseMiddleware<ExceptionHandler>();
app.MapControllers();
app.Run();
