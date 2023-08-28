using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ServiceLayer._SharedFolder.Middlewares
{
    public class ExceptionHandlerWithLogging
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerWithLogging> _logger;

        public ExceptionHandlerWithLogging(RequestDelegate next, ILogger<ExceptionHandlerWithLogging> logger)
        {
            _next = next;
            _logger = logger;
        }
        //we catch all exceptions here and log them in Log.txt 
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unhandled exception occurred: {ex.Message}");

                context.Response.Redirect("/Home/GeneralException");

            }
        }
    }
}
