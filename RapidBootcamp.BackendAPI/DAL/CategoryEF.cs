using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class CategoryEF : ICategory
    {
        private readonly AppDbContext _context;
        public CategoryEF(AppDbContext context)
        {
            _context = context;
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
            var results = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return results;
        }

        public IEnumerable<Category> GetByCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
