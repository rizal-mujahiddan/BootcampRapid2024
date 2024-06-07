﻿namespace RapidBootcamp.WebApplication.Models
{
    public class OrderHeader
    {
        public OrderHeader()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public string OrderHeaderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }

        public Customer Customer { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }

}
