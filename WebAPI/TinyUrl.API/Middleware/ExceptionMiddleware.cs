using System.Net;
using System.Text.Json;
using TinyUrl.API.Helpers;

namespace TinyUrl.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AzureBlobLogger _blobLogger;

        public ExceptionMiddleware(RequestDelegate next, AzureBlobLogger blobLogger)
        {
            _next = next;
            _blobLogger = blobLogger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessage = $@"
Time: {DateTime.UtcNow}
Message: {ex.Message}
StackTrace: {ex.StackTrace}
";

            await _blobLogger.LogAsync(errorMessage);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new
            {
                StatusCode = 500,
                Message = "Internal Server Error"
            });

            await context.Response.WriteAsync(result);
        }
    }
}
