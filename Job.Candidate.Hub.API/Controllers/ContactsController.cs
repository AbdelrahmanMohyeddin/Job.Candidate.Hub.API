using Job.Candidate.Hub.Application.Models.Response;
using Job.Candidate.Hub.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Job.Candidate.Hub.Application.Features.Contacts.Queries.GetAllContacts;
using Job.Candidate.Hub.Domain.Entities;
using Job.Candidate.Hub.Application.Features.Contacts.Queries.GetContactDetails;
using Job.Candidate.Hub.Application.Features.Contacts.Commands.AddOrUpdateContact;
using Job.Candidate.Hub.Application.Features.Contacts.Commands.DeleteContact;

namespace Job.Candidate.Hub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : APIBaseController
    {

        [HttpPost("GetAllContacts", Name = "GetAllContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GenericListQueryResponse<Contact>>> GetAllContacts(GetAllContactsQuery query)
        {
            return await Mediator.Send(query);
        }


        [HttpGet("GetContactDetails/{email}", Name = "GetContactDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericResponse<Contact>>> GetContactDetails(string email)
        {
            return await Mediator.Send(new GetContactDetailsQuery() { Email = email});
        }


        [HttpPost("CreateOrUpdateContact", Name = "CreateOrUpdateContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse>> CreateOrUpdateContact([FromBody] AddOrUpdateContactCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpDelete("DeleteContact/{email}", Name = "DeleteContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse>> DeleteContact(string email)
        {
            return await Mediator.Send(new DeleteContactCommand() { Email = email });
        }
    }
}
