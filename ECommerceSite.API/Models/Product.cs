namespace ECommerceSite.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string description, decimal price)
        {
            Id = id;
            Description = description;
            Price = price;
        }
    }
}