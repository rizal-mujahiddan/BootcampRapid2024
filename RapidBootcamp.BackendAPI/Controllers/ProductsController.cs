using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
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
        public ActionResult<IEnumerable<Product>> Get()
        {
            var results = _product.GetProducsWithCategory();
            return Ok(results);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var results = _product.GetById(id);
            return Ok(results);
        }

        [HttpGet("By")]


        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post(Product product)
        {
            var results = _product.Add(product);
            return CreatedAtAction(nameof(Get),new {ProductId = product.ProductId, product.ProductName,product.Price});
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
