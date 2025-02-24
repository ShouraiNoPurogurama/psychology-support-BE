﻿using BuildingBlocks.Behaviors;
using LifeStyles.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;

namespace LifeStyles.API.Extensions
{
        public static class ApplicationServiceExtensions
        {
            public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
            {
                // services.AddCarter();
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LifeStyles API",
                    Version = "v1"
                }));


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

                services.AddMediatR(configuration =>
                {
                    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
                    configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
                    configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                });

                AddDatabase(services, config);

                AddServiceDependencies(services);

                return services;
            }

            private static void AddServiceDependencies(IServiceCollection services)
            {

            }

            private static void AddDatabase(IServiceCollection services, IConfiguration config)
            {
                var connectionString = config.GetConnectionString("LifeStylesDb");

                services.AddDbContext<LifeStylesDbContext>((sp, opt) =>
                {
                    opt.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                    opt.UseNpgsql(connectionString);
                });
            }
        }
}
