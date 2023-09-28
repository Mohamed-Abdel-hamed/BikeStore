using BikeStore.DTOS;
using BikeStore.Models;
using BikeStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
       
        private readonly IOrderServices _service;

        public OrdersController( IOrderServices service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _service.GetAll();
           
            if (_service.IsEmpty())
                return NotFound("Not Found Any Order!");
            return Ok(order);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound($"Not Found Any Order With Id{id}!");
            return Ok(order);
        }
        [HttpGet("GetByDateOrder")]
        public async Task<IActionResult> GetByDateOrder()
        {
            var order = await _service.GetByDateOrder();
            if (_service.IsEmpty())
                return NotFound($"Not Found Any Order !");
            return Ok(order);
        }
            [HttpPost]
        public async Task<IActionResult>Create(OrderDto orderdto)
        {
            var order = new Order
            {
                Order_status = orderdto.Order_status,
                Order_date = orderdto.Order_date,
                Required_date = orderdto.Required_date,
                Shipped_date = orderdto.Shipped_date,
               Store_id = orderdto.Store_id,
                Staff_id = orderdto.Staff_id,
            };
            await _service.Add(order);
            return Ok(order);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromForm]OrderDto orderdto)
        {
            var order = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound($"Not Found Any Order With Id{id}!");
            order.Order_status = orderdto.Order_status;
            order.Order_date = orderdto.Order_date;
            order.Required_date = orderdto.Required_date;
            order.Shipped_date = orderdto.Shipped_date;
            order.Store_id = orderdto.Store_id;
            order.Staff_id = orderdto.Staff_id;
            await _service.Update(order);
            return Ok(order);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound($"Not Found Any Order With Id{id}!");
            await _service.Delete(order);
            return Ok(order);
        }
    }
}
