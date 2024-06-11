﻿namespace RapidBootcamp.BackendAPI.Models
{
    public class OrderHeader
    {
        public OrderHeader()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public string OrderHeaderId { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public int WalletId { get; set; }

        public Wallet? Wallet { get; set; }
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }
    }

}
