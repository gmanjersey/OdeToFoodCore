using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFoodCore.Data;

namespace OdeToFoodCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            //Execute migrations here to setup EF DB:
            MigrateDatabase(host);
            host.Run();
        }

        private static void MigrateDatabase(IWebHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<OdeToFoodDbContext>();
                db.Database.Migrate();
            };
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //https://github.com/dotnet/aspnetcore/blob/5f7e1a0004a8215b1c5b5bfb0f7fac5335f9b942/src/DefaultBuilder/src/WebHost.cs
        //See Line:156  for CreateDefaultBuilder implementation code.
        //Properties/launchsettings.json can influence what environment you are operating in.
    }
}
