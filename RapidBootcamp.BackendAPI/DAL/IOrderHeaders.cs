using RapidBootcamp.BackendAPI.Models;
using RapidBootcamp.BackendAPI.ViewModels;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface IOrderHeaders : ICrud<OrderHeader>
    {
        public IEnumerable<ViewOrderHeaderInfo> GetAllWithView();
        public string GetOrderLastHeaderId();
    }
}
