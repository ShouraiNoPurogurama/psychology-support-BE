﻿using Feedback.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Feedback.API.Extensions
{
    public static class DatabaseExtensions
    {
        public static void InitializeDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<FeedbackDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            // await SeedAsync(context);
        }
    }
}
