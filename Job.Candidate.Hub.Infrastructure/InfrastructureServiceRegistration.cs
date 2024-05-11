using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Job.Candidate.Hub.Application.Contracts.Infrastructure;

namespace Job.Candidate.Hub.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobCandidateHubDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("JCHConnectionString")));

            services.AddScoped<IJobCandidateHubDbContext>(provider =>
            provider.GetRequiredService<JobCandidateHubDbContext>());


            return services;
        }
    }
}
