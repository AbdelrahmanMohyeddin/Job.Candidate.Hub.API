using AutoMapper;
using Job.Candidate.Hub.Application.Contracts.Infrastructure;
using Job.Candidate.Hub.Application.Mappings;
using Job.Candidate.Hub.Application.Models.Queries;
using Job.Candidate.Hub.Application.Models.Response;
using Job.Candidate.Hub.Domain.Entities;
using MediatR;

namespace Job.Candidate.Hub.Application.Features.Contacts.Queries.GetAllContacts
{
    public class GetAllContactsQuery : GenericListQuery<ContactsFilter>, IRequest<GenericListQueryResponse<Contact>>
    {
    }

    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, GenericListQueryResponse<Contact>>
    {
        private readonly IJobCandidateHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllContactsQueryHandler(IJobCandidateHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GenericListQueryResponse<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            string? email = request.Filter.Email;

            return await _dbContext.Contacts
                .Where(a => (email == null || (email != null &&  a.Email == email)))
                .ProjectToGenericListQueryResponseAsync<Contact, Contact>(_mapper, request.PageNo, request.PageSize);
        }
    }
}
