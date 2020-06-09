using Microsoft.EntityFrameworkCore;
using OdeToFoodCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodCore.Data
{
    public class OdeToFoodDbContext : DbContext 
    {

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
