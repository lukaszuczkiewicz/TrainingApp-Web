using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TraingAppBackEnd.Middleware
{
    public class ErrorHandligMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandligMiddleware> logger;

        public ErrorHandligMiddleware(RequestDelegate next, ILogger<ErrorHandligMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                logger.LogInformation("Middleware is working");
                await next(context);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(context, ex);
            }

        }

        private void HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            logger.LogError(ex, $"Error while handling reqest, status code: {code}");
        }
    }
}
