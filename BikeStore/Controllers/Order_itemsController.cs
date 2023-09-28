using BikeStore.DTOS;
using BikeStore.Models;
using BikeStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_itemsController : ControllerBase
       
    {
        private readonly IOrder_itemServices _service;
       
        public Order_itemsController(IOrder_itemServices service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order_item = await _service.GetAll();
            if(_service.IsEmpty())
            return NotFound("NotFound");
            return Ok(order_item);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var order_item = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound("NotFound");
            return Ok(order_item);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order_itemDto order_itemdto)
        {
            var order_item = new Order_item
            {
                Quantity = order_itemdto.Quantity,
                List_price = order_itemdto.List_price,
                Descount = order_itemdto.Descount,
            };
            await _service.Add(order_item);
            return Ok(order_item);  
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id,Order_itemDto order_itemdto)
        {
            var order_item = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound();
            order_item.Item_id=order_itemdto.Item_id;
            order_item.Order_id=order_itemdto.Order_id;
            order_item.Quantity=order_itemdto.Quantity;
            order_item.List_price=order_itemdto.List_price;
            order_item.Descount=order_itemdto.Descount;
            await _service.Update(order_item);
            return Ok(order_item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var order_item = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound();
            await _service.Delete(order_item);
            return Ok(order_item);
        }
    }
}