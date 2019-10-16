using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Serilog;

namespace TraingAppBackEnd.Middleware
{
    public class ErrorHandligMiddleware
    {
        private readonly RequestDelegate next;
        private readonly Serilog.ILogger logger;

        public ErrorHandligMiddleware(RequestDelegate next, Serilog.ILogger logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invole(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }

        private async Task HandleExceptionAsync(
            HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            logger.Error(ex, $"Error while handling reqest, status code: {code}");
        }
    }
}
