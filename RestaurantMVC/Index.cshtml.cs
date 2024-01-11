using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Data;
using RestaurantMVC.Models;

namespace RestaurantMVC
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantMVC.Data.RestaurantMVCContext _context;

        public IndexModel(RestaurantMVC.Data.RestaurantMVCContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Dish = await _context.Dish.ToListAsync();
        }
    }
}
