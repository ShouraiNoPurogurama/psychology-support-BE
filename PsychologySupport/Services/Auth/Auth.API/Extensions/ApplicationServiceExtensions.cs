﻿using Auth.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;

namespace Auth.API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        services.AddSwaggerGen(option =>
        {
            // option.SwaggerDoc("v1", new OpenApiInfo { Title = "FarmerOnline API", Version = "v1" });
            // option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            // {
            //     In = ParameterLocation.Header,
            //     Description = "Please enter a valid token",
            //     Name = "Authorization",
            //     Type = SecuritySchemeType.Http,
            //     BearerFormat = "JWT",
            //     Scheme = "Bearer"
            // });
            // option.AddSecurityRequirement(new OpenApiSecurityRequirement
            // {
            //     {
            //         new OpenApiSecurityScheme
            //         {
            //             Reference = new OpenApiReference
            //             {
            //                 Type = ReferenceType.SecurityScheme,
            //                 Id = "Bearer"
            //             },
            //             Scheme = "oauth2",
            //             Name = "Bearer",
            //             In = ParameterLocation.Header,
            //         },
            //         new List<string>()
            //     }
        });

        AddDatabase(services, config);

        return services;
    }

    private static void AddDatabase(IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("AuthDb");

        services.AddDbContext<AuthDbContext>((sp, opt) =>
        {
            opt.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            opt.UseNpgsql(connectionString);
        });
    }
}