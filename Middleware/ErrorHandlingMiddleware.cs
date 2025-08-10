using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoApp.Exceptions;

namespace TodoApp.Middleware
{
    public sealed class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var status = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                ValidationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            if (status >= 500)
                _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
            else
                _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);

            var problem = new ProblemDetails
            {
                Status = status,
                Title = status switch
                {
                    400 => "Bad Request",
                    404 => "Not Found",
                    _ => "Internal Server Error"
                },
                Detail = _env.IsDevelopment() ? ex.Message : (status == 500 ? "An unexpected error occured" : ex.Message),
                Instance = httpContext.Request.Path
            };

            problem.Extensions["traceId"] = httpContext.TraceIdentifier;

            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = status;
            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
