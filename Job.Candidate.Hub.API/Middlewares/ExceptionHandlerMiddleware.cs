using System.Net;
using System.Text.Json;
using Job.Candidate.Hub.Application.Exceptions;
using Job.Candidate.Hub.Application.Models.Response;

namespace Job.Candidate.Hub.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var response = new BaseResponse
            {
                Success = false,
                Message = exception.Message,
            };

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    response.Errors = validationException.Errors;
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case ForbiddenAccessException forbiddenAccessException:
                    httpStatusCode = HttpStatusCode.Forbidden;
                    break;
                case Exception:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            string content = JsonSerializer.Serialize(response, serializeOptions);

            return context.Response.WriteAsync(content);
        }
    }
}
