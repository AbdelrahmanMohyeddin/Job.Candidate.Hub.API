using MediatR;
using Microsoft.Extensions.Logging;
using Job.Candidate.Hub.Application.Exceptions;

namespace Job.Candidate.Hub.Application.Common.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                if (ex.GetType().BaseType != typeof(BaseApplicationException))
                {
                    ex = new UnhandledException("System Error please contact your system Admin", ex);
                }

                _logger.LogError(ex, "Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

                throw ex;
            }
        }
    }
}
