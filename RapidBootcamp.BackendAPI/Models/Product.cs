namespace RapidBootcamp.BackendAPI.Models
{
    public class Product
    {
        public Product()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
