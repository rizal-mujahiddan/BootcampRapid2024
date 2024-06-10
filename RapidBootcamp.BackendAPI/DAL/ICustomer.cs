using RapidBootcamp.BackendAPI.Models;
namespace RapidBootcamp.BackendAPI.DAL
{
    public interface ICustomer : ICrud<Customer>
    {
        IEnumerable<Customer> GetCustomersByName(string customerName);
        IEnumerable<Customer> GetCustomersByCity(string city);
        IEnumerable<Customer> GetCustomersByNameOrCity(string customerNameOrCity);
    }
}
