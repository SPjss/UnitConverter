using System.Net;
using System.Text.Json;

namespace UnitConverter.Middleware
{
    public class ExceptionhandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionhandlerMiddleware> _logger;

        public ExceptionhandlerMiddleware(RequestDelegate next, ILogger<ExceptionhandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Bad request: {Message}", ex.Message);
                await WriteErrorResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await WriteErrorResponse(context, HttpStatusCode.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        private static async Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = JsonSerializer.Serialize(new { error = message });
            await context.Response.WriteAsync(response);
        }
    }
}
