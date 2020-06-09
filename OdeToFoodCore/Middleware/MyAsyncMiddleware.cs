using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodCore.Middleware
{

    /// <summary>
    /// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    /// </summary>
    public class MyAsyncMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger _logger;
        
        public MyAsyncMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            this.next = next;
            this._logger = logFactory.CreateLogger("MyAsyncMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("MyAsyncMiddleware executing...");
            await next(httpContext);
        }
    }

}
