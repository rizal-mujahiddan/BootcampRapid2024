namespace RapidBootcamp.WebApplication.Models
{
    public class Wallet
    {
        public Wallet()
        {
            this.OrderHeaders = new List<OrderHeader>();
        }

        public int WalletId { get; set; }
        public int CustomerId { get; set; }
        public string WalletName { get; set; } = null!;
        public decimal Saldo { get; set; }

        public Customer Customer { get; set; }
        public IEnumerable<OrderHeader> OrderHeaders { get; set; }
    }

}
