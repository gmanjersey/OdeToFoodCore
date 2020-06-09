using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdeToFoodCore.Data;
using OdeToFoodCore.Middleware;

namespace OdeToFoodCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            
            
            /*TODO: uncomment after deployment to IIS: */
            services.AddScoped<IRestaurantData, SqlRestaurantData>();   //Cannot use a singleton for LIVE database with concurrent users.

            /*Uncommented when deploying to IIS and you want to test the app then comment after creating migration script for EF:*/
            //services.AddScoped<IRestaurantData, InMemoryRestaurantData>(); 

            
            services.AddDbContextPool<OdeToFoodDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb")) );

            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /// <summary>
        /// Will Now, we need to add our custom middleware  MyAsyncMiddleware in the request 
        /// pipeline by using Use extension method as:
        ///  app.MyAsyncMiddleware();
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //This method is used to Add Http Middleware:
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection(); //do not use if you are using  app.UseHsts()

            app.UseStaticFiles();       //Request for jQuery.js and if find the file in wwwroot folder it will return it from WebServer:
                                        //it will take a file of Type StaticFileOptions

            app.UseNodeModules(env);   // Uses the IHosting Environment that is passed in th configure method 
                                       // and will support cookie policy. MVC framework - razor pages and Api Controller
                                       // and also to use Node Modules for script files
            
            app.UseCookiePolicy();     // Set cookie policy - Asp.net consent cookie.


            //app.UseAuthentication()  // This is done later in the pipeline.
            //app.UseSignalR()         //  Realtime Websocket communications

            app.UseMyAsyncMiddleware();

            app.UseMvc();             // this middleware is like a router middleware - try to render a razor page or razor view.

            //app.UseSpa()            //For single page applications
            //app.UseCors             //Allows Cross Domain Request - by adding Cross Origin Resources Sharing headers.

            //Simple middleware
           // app.Use(SayHelloMiddleware); 
        }

        private RequestDelegate SayHelloMiddleware(RequestDelegate arg)
        {
            return async ctx =>
            {

                if (ctx.Request.Path.StartsWithSegments("hello"))
                {
                    await ctx.Response.WriteAsync("Hello, World!");
                }
                else
                {
                   //await Next(ctx);
                }
            };
        }
    }
    

}
