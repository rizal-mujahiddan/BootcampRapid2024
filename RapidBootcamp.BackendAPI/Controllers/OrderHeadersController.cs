using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.Models;
using RapidBootcamp.BackendAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHeadersController : ControllerBase
    {
        private readonly IOrderHeaders _orderHeaders;
        public OrderHeadersController(IOrderHeaders orderHeaders)
        {
            _orderHeaders = orderHeaders;
        }
        // GET: api/<OrderHeadersController>
        [HttpGet]
        public IEnumerable<OrderHeader> Get()
        {
            var results = _orderHeaders.GetAll();
            return results;
        }

        [HttpGet("View")]
        public IEnumerable<ViewOrderHeaderInfo> GetAllWithView()
        {
            var results = _orderHeaders.GetAllWithView();
            return results;
        }

        // GET api/<OrderHeadersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderHeadersController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderHeader orderHeader)
        {
            try
            {
                string lastOrderHeaderId = _orderHeaders.GetOrderLastHeaderId();
                lastOrderHeaderId = lastOrderHeaderId.Substring(4, 4);
                int newOrderHeaderId = Convert.ToInt32(lastOrderHeaderId) + 1;
                string newOrderHeaderIdString = "INV-" + newOrderHeaderId.ToString("D4");

                orderHeader.OrderHeaderId = newOrderHeaderIdString;
                var result = _orderHeaders.Add(orderHeader);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // PUT api/<OrderHeadersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderHeadersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
