namespace RapidBootcamp.BackendAPI.Models
{
    public class Wallet
    {
        public Wallet()
        {
            this.OrderHeaders = new List<OrderHeader>();
        }

        public int WalletId { get; set; }
        public int CustomerId { get; set; }
        public int WalletTypeId { get; set; }
        public decimal Saldo { get; set; }

        public Customer? Customer { get; set; }
        public WalletType? WalletType { get; set; }
        public IEnumerable<OrderHeader>? OrderHeaders { get; set; }
    }

}
