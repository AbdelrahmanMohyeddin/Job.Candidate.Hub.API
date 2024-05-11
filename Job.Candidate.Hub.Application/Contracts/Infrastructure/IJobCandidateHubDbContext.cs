using Job.Candidate.Hub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Job.Candidate.Hub.Application.Contracts.Infrastructure
{
    public interface IJobCandidateHubDbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
