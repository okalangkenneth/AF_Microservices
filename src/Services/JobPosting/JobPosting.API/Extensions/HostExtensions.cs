using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace JobPosting.API.Extensions
{
    public static class HostExtensions
    {
        // This method migrates the database associated with the given DbContext.
        // It also accepts a seeder action that can be used to seed the database with initial data.
        public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            // Create a new scope from the host's services
            using (var scope = host.Services.CreateScope())
            {
                // Get the necessary services and logger from the scope
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    // Call the Migrate() method on the context's Database property to perform any pending migrations
                    context.Database.Migrate();

                    // Invoke the seeder action with the context and services
                    seeder(context, services);

                    // Log a success message
                    logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
                }
                catch (SqlException ex)
                {
                    // Log an error message with the exception
                    logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
                }
            }

            // Return the host
            return host;
        }

        // This private method invokes the given seeder action with the given DbContext and services.
        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
            where TContext : DbContext
        {
            // Call the Migrate() method on the context's Database property to perform any pending migrations
            context.Database.Migrate();

            // Invoke the seeder action with the context and services
            seeder(context, services);
        }
    }
}

