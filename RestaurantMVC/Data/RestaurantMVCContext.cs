using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Models;

namespace RestaurantMVC.Data
{
    public class RestaurantMVCContext : DbContext
    {
        public RestaurantMVCContext (DbContextOptions<RestaurantMVCContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantMVC.Models.Dish> Dish { get; set; } = default!;
    }
}
