using Auth.API.Extensions;
using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var services = builder.Services;

services.AddExceptionHandler<CustomExceptionHandler>();

services.AddApplicationServices(builder.Configuration);
services.AddIdentityServices(builder.Configuration);

// Configure the HTTP request pipeline
var app = builder.Build();

app.UseExceptionHandler(options => { });

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.InitializeDatabaseAsync();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth API v1");
});

// Apply CORS policy
app.UseCors(config =>
{
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowAnyOrigin();
});

app.MapControllers();

app.Run();