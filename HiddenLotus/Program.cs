using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HiddenLotus.Data;
using HiddenLotus.ChatSystem;
using Newtonsoft.Json;
using WebSocketSharp.Server;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HiddenLotusContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HiddenLotusContext") ?? throw new InvalidOperationException("Connection string 'HiddenLotusContext' not found.")));

// Add services to the container.
builder.Services.AddSingleton<ChatSystem>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var wssv = new WebSocketServer("ws://0.0.0.0:8080");
wssv.AddWebSocketService<ChatBehavior>("/ws");

// Khởi động server
wssv.Start();
app.Logger.LogInformation("Server started on ws://0.0.0.0:8080");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebSockets();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
