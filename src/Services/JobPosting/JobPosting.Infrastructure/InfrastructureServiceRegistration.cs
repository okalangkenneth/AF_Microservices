using JobPosting.Application.Contracts.Infrastructure;
using JobPosting.Application.Contracts.Persistence;
using JobPosting.Application.Models;
using JobPosting.Infrastructure.Mail;
using JobPosting.Infrastructure.Persistence;
using JobPosting.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobPosting.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobPostingContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("JobPostingConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IJobPostingRepository, JobPostingRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }

    }
}
