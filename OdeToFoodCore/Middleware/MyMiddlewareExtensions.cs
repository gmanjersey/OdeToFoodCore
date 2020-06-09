using Microsoft.AspNetCore.Builder;

namespace OdeToFoodCore.Middleware
{
    public static class MyMiddlewareExtensions
    {
        /// <summary>
        /// Extension method used to add the middleware to the HTTP request pipeline.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }

    }

}
