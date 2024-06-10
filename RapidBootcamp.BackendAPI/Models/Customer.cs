namespace RapidBootcamp.BackendAPI.Models
{
    public class Customer
    {
        public Customer()
        {
            this.OrderHeaders = new List<OrderHeader>();
            this.Wallets = new List<Wallet>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; }

        public IEnumerable<OrderHeader> OrderHeaders { get; set; }
        public IEnumerable<Wallet> Wallets { get; set; }
    }
}
