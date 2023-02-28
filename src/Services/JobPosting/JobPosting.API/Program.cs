using JobPosting.API.Extensions;
using JobPosting.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JobPosting.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
                var host = CreateHostBuilder(args).Build();
                host.MigrateDatabase<JobPostingContext>((context,services) =>
                {
                    var logger = services.GetService<ILogger<JobPostingContextSeed>>();
                    JobPostingContextSeed
                     .SeedAsync(context, logger)
                     .Wait();
                });

                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
