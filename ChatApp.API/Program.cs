using ChatApp.Application.Services;
using ChatApp.Infrastructure.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS to allow your React app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:3000") // React app URL
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()); // If using credentials
});

// Add SignalR
builder.Services.AddSignalR();
builder.Services.AddSingleton<ChatService>();

var app = builder.Build();

app.UseCors("AllowReactApp"); // Use the updated CORS policy

// Map SignalR Hub
app.MapHub<ChatHub>("/chatHub");

app.Run();
