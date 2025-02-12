using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Sample.Common
{
    public class GlobalExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var errorid = Guid.NewGuid();
                _logger.LogError(ex, $"{errorid}:{ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var error = new
                {
                    id=errorid,
                    message = "An error occurred while processing your request"
                };
                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
