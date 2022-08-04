namespace Aniverse.API.Middelwares
{
    public static class ExceptionHandlerMiddelwareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddelware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddelware>();
        }
    }
}
