using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface IOrderDetail : ICrud<OrderDetail>
    {
        IEnumerable<OrderDetail> GetDetailsByHeaderId(string orderHeaderId);
        decimal GetTotalAmount(string orderHeaderId);

    }
}