namespace RapidBootcamp.WebApplication.Models
{
    public class Customer
    {
        public Customer()
        {
            this.OrderHeaders = new List<OrderHeader>();
        }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<OrderHeader> OrderHeaders { get; set; }
    }

}
