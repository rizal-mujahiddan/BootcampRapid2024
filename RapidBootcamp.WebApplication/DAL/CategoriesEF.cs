using RapidBootcamp.WebApplication.Models;
using System.Collections;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CategoriesEF : ICategory
    {
        private readonly AppDbContext _dbContext;
        public CategoriesEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Category Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            var results  = _dbContext.Categories.ToList();
            //var results = from c in _dbContext.Categories
            //              orderby c.CategoryName ascending
            //              select c;
            return results.ToList();
        }

        public Category GetById(int id)
        {
            //var results = _dbContext.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            var results = (from c in _dbContext.Categories
                           where c.CategoryId == id
                           select c).FirstOrDefault();

            if (results == null)
            {
                throw new ArgumentException("Category not found");
            }
            else
            {
                return results;
            }   
        }
        public IEnumerable<Category> GetCategoriesByName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
