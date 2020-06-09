using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodCore.Middleware
{

    /// <summary>
    /// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    /// </summary>
    public class MyMiddleware
    {
        private readonly RequestDelegate next;

        public MyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            return next(httpContext);
        }
    }

}
