using Test.API;
using Test.Application;
using Test.Application.Extensions;
using Test.Infrastructure;
using Test.Infrastructure.Data.Extensions;


var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;

builder.Configuration
    .AddJsonFile($"appsettings.{env}.json", optional: true,
        reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add services to the container
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration)
    .RegisterMapsterConfiguration();

var app = builder.Build();

//Configure the HTTP request pipeline
app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API v1");
});

// Apply CORS policy
app.UseCors(config =>
{
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowAnyOrigin();
});

app.Run();