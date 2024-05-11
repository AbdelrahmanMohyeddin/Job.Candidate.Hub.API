using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Job.Candidate.Hub.Domain.Entities;
using Job.Candidate.Hub.Application.Contracts.Infrastructure;

namespace Job.Candidate.Hub.Infrastructure
{
    public class JobCandidateHubDbContext : DbContext, IJobCandidateHubDbContext
    {

        public JobCandidateHubDbContext(DbContextOptions<JobCandidateHubDbContext> options)
         : base(options)
        {
        }


        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }

}
