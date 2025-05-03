using Microsoft.AspNetCore.Cors;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Конфигурация
builder.Configuration
    .AddJsonFile("ocelot.json")
    .AddEnvironmentVariables();

// Сервисы
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Ocelot
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Middleware pipeline
app.UseRouting();

// CORS должно быть перед UseOcelot
app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
    context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
    context.Response.Headers.Append("Access-Control-Allow-Headers", "Content-Type, Authorization");
    await next();
});

app.UseOcelot().Wait();

app.MapControllers();

app.Run();