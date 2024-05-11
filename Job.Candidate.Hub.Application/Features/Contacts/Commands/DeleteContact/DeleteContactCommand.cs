using Job.Candidate.Hub.Application.Contracts.Infrastructure;
using Job.Candidate.Hub.Application.Exceptions;
using Job.Candidate.Hub.Application.Models.Response;
using Job.Candidate.Hub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Job.Candidate.Hub.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<BaseResponse>
    {
        public string Email { get; set; }
    }


    internal class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, BaseResponse>
    {
        private readonly IJobCandidateHubDbContext _dbContext;

        public DeleteContactCommandHandler(IJobCandidateHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<BaseResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            Contact? contact = await _dbContext.Contacts
                .FirstOrDefaultAsync(a => a.Email == request.Email, cancellationToken);

            if(contact == null)
            {
                throw new NotFoundException(nameof(Contact), request.Email);
            }

            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return new BaseResponse();
        }
    }
}
