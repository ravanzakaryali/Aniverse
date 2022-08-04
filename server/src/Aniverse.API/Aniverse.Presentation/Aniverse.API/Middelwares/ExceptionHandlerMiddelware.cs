using Aniverse.Application.DTOs.Common;
using System.Net;
using System.Text.Json;

namespace Aniverse.API.Middelwares
{
    public class ExceptionHandlerMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddelware(RequestDelegate next, ILogger<ExceptionHandlerMiddelware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                ErrorReponse error = await HandleExceptionAsync(httpContext, ex);
                _logger.LogError($"Request {httpContext.Request?.Method}: {httpContext.Request?.Path.Value} failed Error: {@error}", error);
            }
        }
        private async Task<ErrorReponse> HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ErrorReponse reponse = new()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
            };
            var json = JsonSerializer.Serialize(reponse);
            await context.Response.WriteAsync(json);
            return reponse;
        }
    }
}
 