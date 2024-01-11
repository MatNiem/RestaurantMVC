namespace RestaurantMVC.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Ingrediants { get; set; }
        public string Preperation { get; set; }
        public Boolean IsAvailable { get; set; }
        public int kcal { get; set; } = 0;

        public Dish(int id, string name, decimal price, string ingrediants, string preperation, bool isAvailable)
        {
            Id = id;
            Name = name;
            Price = price;
            Ingrediants = ingrediants;
            Preperation = preperation;
            IsAvailable = isAvailable;
        }


        public Dish() { }
    }
}
