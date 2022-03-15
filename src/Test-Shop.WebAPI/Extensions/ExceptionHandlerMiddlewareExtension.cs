using Microsoft.AspNetCore.Builder;

namespace Test_Shop.WebAPI.Extensions
{
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
