namespace RapidBootcamp.BackendAPI.ViewModels
{
    public class ViewOrderDetail
    {
        public string OrderHeaderId { get; set; } = null!;
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; } = null!;
    }

}
