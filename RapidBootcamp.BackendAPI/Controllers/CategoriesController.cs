using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.DTO;
using RapidBootcamp.BackendAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoriesController(ICategory category)
        {
            _category = category;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
            var categories = _category.GetAll();

            foreach (var category in categories)
            {
                CategoryDTO categoryDTO = new CategoryDTO
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
                categoryDTOs.Add(categoryDTO);
            }
            return categoryDTOs;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public CategoryDTO Get(int id)
        {
            var category = _category.GetById(id);
            CategoryDTO categoryDTO = new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };

            return categoryDTO;
        }

        [HttpGet("ByName")]
        public IEnumerable<Category> GetByName(string name)
        {
            var categories = _category.GetByCategoryName(name);
            return categories;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult Post(CreateCategoryDTO createCategoryDto)
        {
            try
            {
                Category category = new Category
                {
                    CategoryName = createCategoryDto.CategoryName
                };
                var result = _category.Add(category);

                CategoryDTO categoryDTO = new CategoryDTO
                {
                    CategoryId = result.CategoryId,
                    CategoryName = result.CategoryName
                };

                return CreatedAtAction(nameof(Get),
                    new { id = category.CategoryId }, categoryDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Category category)
        {
            var updateData = _category.GetById(id);
            try
            {
                if (updateData != null)
                {
                    updateData.CategoryName = category.CategoryName;
                    var result = _category.Update(updateData);
                    return Ok(result);
                }
                return BadRequest($"Category {category.CategoryName} not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }


        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var deleteData = _category.GetById(id);
                if (deleteData != null)
                {
                    _category.Delete(deleteData.CategoryId);
                    return Ok($"Data Category Id {id} berhasil didelete");
                }
                return BadRequest($"Data Category Id {id} Not Found !");
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not delete {ex.Message}");
            }
        }
    }
}