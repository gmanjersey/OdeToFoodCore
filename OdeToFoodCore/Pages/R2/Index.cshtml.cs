using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFoodCore.Core;
using OdeToFoodCore.Data;

namespace OdeToFoodCore.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly OdeToFoodCore.Data.OdeToFoodDbContext _context;

        public IndexModel(OdeToFoodCore.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
