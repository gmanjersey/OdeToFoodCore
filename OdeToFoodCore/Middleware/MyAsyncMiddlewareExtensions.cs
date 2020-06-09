using Microsoft.AspNetCore.Builder;

namespace OdeToFoodCore.Middleware
{
    public static class MyAsyncMiddlewareExtensions
    {
        /// <summary>
        /// Extension method used to add the middleware to the HTTP request pipeline.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMyAsyncMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyAsyncMiddleware>();
        }

    }

}
