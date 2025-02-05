using ChatApp.Application.Services;
using ChatApp.Infrastructure.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddSignalR();
builder.Services.AddSingleton<ChatService>();

var app = builder.Build();

app.UseCors("AllowAll");

app.MapHub<ChatHub>("/chatHub");

app.Run();
