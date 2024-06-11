namespace RapidBootcamp.BackendAPI.Models
{
    public class WalletType
    {
        public WalletType()
        {
            this.Wallets = new List<Wallet>();
        }
        public int WalletTypeId { get; set; }
        public string WalletName { get; set; } = null!;
        public IEnumerable<Wallet>? Wallets { get; set; }
    }

}
