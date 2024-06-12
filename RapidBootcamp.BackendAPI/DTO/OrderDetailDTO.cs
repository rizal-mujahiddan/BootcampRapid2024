namespace RapidBootcamp.BackendAPI.DTO
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }
        public string OrderHeaderId { get; set; } = null!;
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        //public IEnumerable<OrderDetailDTO>? OrderDetails { get; set; }

    }
}
