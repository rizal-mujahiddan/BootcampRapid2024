﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IOrderDetail _orderDetail;
        public OrderHeadersController(IOrderHeaders orderHeaders, IOrderDetail orderDetail)
        {
            _orderHeaders = orderHeaders;
            _orderDetail = orderDetail;
        }

        // GET: api/<OrderHeadersController>
        [HttpGet]
        public IEnumerable<OrderHeader> Get()
        {
            var results = _orderHeaders.GetAll();
            foreach (var item in results) {
                item.OrderDetails = _orderDetail.GetDetailsByHeaderId(item.OrderHeaderId);
            }
            return results;
        }

        [HttpGet("View")]
        public IEnumerable<ViewOrderHeaderInfo> GetWithView()
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
                //ambil last orderheaderid
                string lastOrderHeaderId = _orderHeaders.GetOrderLastHeaderId();

                lastOrderHeaderId = lastOrderHeaderId.Substring(4, 4);
                int newOrderHeaderId = Convert.ToInt32(lastOrderHeaderId) + 1;
                string newOrderHeaderIdString = "INV-" + newOrderHeaderId.ToString("D4");

                orderHeader.OrderHeaderId = newOrderHeaderIdString;

                var result = _orderHeaders.Add(orderHeader);
                foreach (var item in orderHeader.OrderDetails)
                {
                    item.OrderHeaderId = newOrderHeaderIdString;
                    _orderDetail.Add(item);
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
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