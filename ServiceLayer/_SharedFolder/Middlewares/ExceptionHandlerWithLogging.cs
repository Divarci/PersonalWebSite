using CoreLayer.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ServiceLayer.BlogApiClient.Exceptions;

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
                if (ex is CustomNullException)
                {
                    _logger.LogError(ex, $"Unhandled exception occurred: {ex.Message}");

                    string queryString = "?errors=" + Uri.EscapeDataString(ex.Message)+ "?" + Uri.EscapeDataString("404");
                    context.Response.Redirect("/BlogApi/Dashboard/Error"+queryString);
                    return;
                }
                if(ex is ConflictException)
                {
                    _logger.LogError(ex, $"Unhandled exception occurred: {ex.Message}");

                    string queryString = "?errors=" + Uri.EscapeDataString(ex.Message) + "?" + Uri.EscapeDataString("409");
                    context.Response.Redirect("/BlogApi/Dashboard/Error" + queryString);
                    return;

                }

                _logger.LogError(ex, $"Unhandled exception occurred: {ex.Message}");

                context.Response.Redirect("/Home/GeneralException");
                return;

            }
        }
    }
}
