using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackendAPI.Models;
using RapidBootcamp.BackendAPI.ViewModels;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class OrderHeaderEF : IOrderHeaders
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _appDbContext;
        public OrderHeaderEF(IConfiguration config,AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _config = config;
        }
        public OrderHeader Add(OrderHeader entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            var results = _appDbContext.OrderHeaders
                .Include(oh => oh.Wallet).ThenInclude(w => w.Customer)
                .Include(oh => oh.Wallet).ThenInclude(w => w.WalletType)
                .Include(od => od.OrderDetails).ThenInclude(p=>p.Product).ToList();
            return results;
        }

        public IEnumerable<ViewOrderHeaderInfo> GetAllWithView()
        {
            throw new NotImplementedException();
        }

        public OrderHeader GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetOrderLastHeaderId()
        {
            throw new NotImplementedException();
        }

        public OrderHeader Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }
    }
}
