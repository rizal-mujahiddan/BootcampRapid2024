namespace RapidBootcamp.BackendAPI.DTO
{
    public class CategoryDTO
    {
        //public Category()
        //{
        //    this.Products = new List<Product>();
        //}
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        //public IEnumerable<Product>? Products { get; set; }
    }
}
