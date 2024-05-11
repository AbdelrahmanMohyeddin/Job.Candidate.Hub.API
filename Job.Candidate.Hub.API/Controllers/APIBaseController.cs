using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Job.Candidate.Hub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class APIBaseController : ControllerBase
    {
        private IMediator _mediator = null!;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
