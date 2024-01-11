using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Data;

namespace RestaurantMVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RestaurantMVCContext(serviceProvider.GetRequiredService<DbContextOptions<RestaurantMVCContext>>()))
            {
                if (context.Dish.Any())
                {
                    return;
                }

                context.Dish.AddRange(
                    new Dish
                    {
                        Id = 1,
                        Name = "marchew",
                        Price = 3,
                        Ingrediants = "marchew",
                        Preperation = "Nope",
                        IsAvailable = true
                    },

                    new Dish
                    {
                        Id = 2,
                        Name = "parówki",
                        Price = 5,
                        Ingrediants = "parówki",
                        Preperation = "gotuj",
                        IsAvailable = true
                    },

                    new Dish
                    {
                        Id = 3,
                        Name = "aa",
                        Price = 10,
                        Ingrediants = "ab",
                        Preperation = "ac",
                        IsAvailable = true
                    },

                    new Dish
                    {
                        Id = 4,
                        Name = "ba",
                        Price = 20,
                        Ingrediants = "bb",
                        Preperation = "bc",
                        IsAvailable = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
