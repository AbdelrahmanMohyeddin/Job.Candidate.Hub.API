using Job.Candidate.Hub.Application.Contracts.Infrastructure;
using Job.Candidate.Hub.Application.Exceptions;
using Job.Candidate.Hub.Application.Models.Response;
using Job.Candidate.Hub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Job.Candidate.Hub.Application.Features.Contacts.Queries.GetContactDetails
{
    public class GetContactDetailsQuery : IRequest<GenericResponse<Contact>>
    {
        public string Email { get; set; }
    }

    public class GetContactDetailsQueryHandler : IRequestHandler<GetContactDetailsQuery, GenericResponse<Contact>>
    {
        private readonly IJobCandidateHubDbContext _dbContext;

        public GetContactDetailsQueryHandler(IJobCandidateHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GenericResponse<Contact>> Handle(GetContactDetailsQuery request, CancellationToken cancellationToken)
        {
            Contact? contact = await _dbContext.Contacts
                .FirstOrDefaultAsync(a => a.Email == request.Email, cancellationToken);

            if(contact == null)
            {
                throw new NotFoundException(nameof(Contact), request.Email);
            }

            return new GenericResponse<Contact>
            {
                Result = contact
            };
        }
    }
}
