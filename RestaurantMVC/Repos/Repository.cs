using RestaurantMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantMVC.Repos
{
    public static class Repository
    {
        private static List<Dish> dishes = new List<Dish>()
        {
            // dodaj jakieś obiekty

            new Dish(1, "Danie 1", 5, "Skladnik 1 i 2", "przygotowanie 1", true),
            new Dish(2, "Danie 2", 2, "Skladnik 2 i 3", "przygotowanie 2", false),
            new Dish(3, "Danie 3", 15, "Skladnik 3 i 1", "przygotowanie 3", true),
            new Dish(4, "Danie 4", 12, "Skladnik 4 i 3", "przygotowanie 4", true),
            new Dish(5, "Danie 5", 27, "Skladnik 4 i 2", "przygotowanie 5", true)
        };


        public static IEnumerable<Dish> Dishes => dishes;

        public static void AddDish(Dish dish)
        {
            // zaimplementuj

            if (dish == null)
            {
                throw new ArgumentNullException(nameof(dish));
            }
            dish.Id = dishes.Count + 1;
            dish.IsAvailable = true;
            dishes.Add(dish);
        }

        public static void RemoveDish(int? id)
        {
            // zaimplementuj

            if (id.HasValue)
            {
                Dish dishToRemove = dishes.FirstOrDefault(d => d.Id == id.Value);
                if (dishToRemove != null)
                {
                    dishToRemove.IsAvailable = false;
                }
                else
                {
                    Console.WriteLine($"Dish with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("ID cannot be null.");
            }
        }
    }
}
