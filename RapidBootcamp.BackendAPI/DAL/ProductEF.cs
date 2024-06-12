using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class ProductEF : IProduct
    {
        private readonly AppDbContext _appDbcontext;
        public ProductEF(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext; 
        }
        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var results = _appDbcontext.Products.Include(p => p.Category)
                .OrderBy(p => p.ProductId).ToList();
            return results;
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByProductName(string productName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducsWithCategory()
        {
            var results = _appDbcontext.Products.Include(p=> p.Category).OrderBy(p => p.ProductId).ToList();
            return results;
        }

        public int GetProductStock(int productId)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
