using Job.Candidate.Hub.Application.Contracts.Infrastructure;
using Job.Candidate.Hub.Application.Models.Response;
using Job.Candidate.Hub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Job.Candidate.Hub.Application.Features.Contacts.Commands.AddOrUpdateContact
{
    public class AddOrUpdateContactCommand : Contact, IRequest<BaseResponse>
    {
    }


    internal class AddOrUpdateContactCommandHandler : IRequestHandler<AddOrUpdateContactCommand, BaseResponse>
    {
        private readonly IJobCandidateHubDbContext _dbContext;

        public AddOrUpdateContactCommandHandler(IJobCandidateHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> Handle(AddOrUpdateContactCommand request, CancellationToken cancellationToken)
        {
         
            Contact? contact = await _dbContext.Contacts
                .FirstOrDefaultAsync(a => a.Email == request.Email, cancellationToken);

            if(contact == null)
            {
                await _dbContext.Contacts.AddAsync(request, cancellationToken);
            }
            else
            {
                contact.FirstName = request.FirstName; 
                contact.LastName = request.LastName;
                contact.PhoneNumber = request.PhoneNumber;
                contact.TimeInterval = request.TimeInterval;
                contact.LinkedInProfileURL = request.LinkedInProfileURL;
                contact.GithubProfileURL = request.GithubProfileURL;
                contact.Remarks = request.Remarks;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new BaseResponse();
        }
    }
}
