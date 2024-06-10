using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class ProductsEF : IProduct
    {
        private readonly AppDbContext _appDbContext;
        public ProductsEF(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Product Add(Product entity)
        {
            try
            {
                _appDbContext.Products.Add(entity);
                _appDbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var results = _appDbContext.Products.Include(p => p.Category);
            return results.ToList();
        }

        public Product GetById(int id)
        {

            try
            {
                var result = _appDbContext.Products.Where(p => p.ProductId == id).FirstOrDefault();
                if (result == null)
                {
                    return result;
                }
                else {
                    throw new ArgumentException($"Product Id:{id} tidak ada");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByName(string productName)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
