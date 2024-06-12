using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.DTO;
using RapidBootcamp.BackendAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductsController(IProduct product)
        {
            _product = product;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            var products = _product.GetProducsWithCategory();
            foreach (var product in products)
            {
                ProductDTO productDTO = new ProductDTO
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Stock = product.Stock,
                    Category = new CategoryDTO
                    {
                        CategoryId = product.Category.CategoryId,
                        CategoryName = product.Category.CategoryName,
                    }

                };
                productDTOs.Add(productDTO);
            }


            return productDTOs;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _product.GetById(id);

            return product;
        }

        [HttpGet("ByCategory/{CategoryId}")]
        public IEnumerable<Product> GetByCategory(int CategoryId)
        {
            var products = _product.GetByCategory(CategoryId);
            return products;
        }

        [HttpGet("ByProductName")]
        public ActionResult<IEnumerable<Product>> GetByCategory(string name)
        {
            var products = _product.GetByProductName(name);
            return Ok(products);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post(Product product)
        {
            try
            {
                var results = _product.Add(product);
                return CreatedAtAction(nameof(Get), new { id = results.ProductId }, results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product
            )
        {
            var updateProduct = _product.GetById(id);
            if(updateProduct == null)
            {
                return NotFound(); 
            }
            try
            {
                updateProduct.ProductName = product.ProductName;
                updateProduct.ProductId = product.CategoryId;
                updateProduct.Stock = product.Stock;
                updateProduct.Price = product.Price;
                var result = _product.Update(updateProduct);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleteProduct = _product.GetById(id);
            if (deleteProduct == null) { 
                return NotFound();
            }
            try
            {
                _product.Delete(id);
                return Ok($"Product {id} berasil didelete...");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}