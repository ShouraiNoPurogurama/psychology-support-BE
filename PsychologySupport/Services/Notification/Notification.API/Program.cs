using BuildingBlocks.Exceptions.Handler;
using Carter;
using Notification.API;
using Notification.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.Configure<AppSettings>(builder.Configuration);

// services.AddCarter();

services.AddApplicationServices(builder.Configuration);

services.ConfigureEmailFeature(builder.Configuration);

services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.UseExceptionHandler(options => {});

app.UseStaticFiles();

app.MapCarter();

if (app.Environment.IsDevelopment())
{
    app.InitializeDatabaseAsync();    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification API v1");
    });
}

app.UseCors();

app.Run();