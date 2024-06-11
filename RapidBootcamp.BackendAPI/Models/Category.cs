namespace RapidBootcamp.BackendAPI.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public IEnumerable<Product>? Products { get; set; }
    }

}
