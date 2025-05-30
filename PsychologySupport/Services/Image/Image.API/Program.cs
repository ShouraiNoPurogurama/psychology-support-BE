using BuildingBlocks.Exceptions.Handler;
using Carter;
using Image.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.LoadConfiguration(builder.Environment);

var services = builder.Services;

services.AddApplicationServices(builder.Configuration);

services.AddExceptionHandler<CustomExceptionHandler>();

services.RegisterMapsterConfiguration();


// Configure the HTTP request pipeline
var app = builder.Build();

app.UseExceptionHandler(options => { });

app.UseStaticFiles();

app.MapCarter();

if (app.Environment.IsDevelopment())
{
    app.InitializeDatabaseAsync();
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Image API v1"); });
}


// Apply CORS policy
app.UseCors(config =>
{
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowAnyOrigin();
});

app.MapControllers();

app.UseRouting();
app.UseAuthorization();


app.Run();
