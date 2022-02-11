namespace ECommerceSite.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
    }
}