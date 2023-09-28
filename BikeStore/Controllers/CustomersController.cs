using BikeStore.DTOS;
using BikeStore.Models;
using BikeStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Numerics;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _services;

       public CustomersController(ICustomerServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var customers = await _services.GetAll();
            if (_services.IsEmpty())
                return NotFound("NotFound Any Customer !");
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
         
           var customer = await _services.GetById(id);
            if (_services.IsEmpty())
                return NotFound($"NotFound Any Customer With Id{id} !");
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerdto)
        {
            Customer customer = new Customer
            {
                Customer_name = customerdto.Customer_name,
                Phone = customerdto.Phone,
                Email = customerdto.Email,
                Street = customerdto.Street,
                City = customerdto.City,
                State = customerdto.State,
                Zip_code = customerdto.Zip_code
            };
            if (!_services.IsEmailValid(customer.Email))
                return BadRequest("Email Not Valid !");
                await _services.Add(customer);
            return Ok(customer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CustomerDto customerdto)
        {
            var customer = await _services.GetById(id);
            if (_services.IsEmpty())
                return NotFound($"NotFound Any Customer With Id{id} !");
            customer.Customer_name = customerdto.Customer_name;
            customer.Phone = customerdto.Phone;
            customer.Email = customerdto.Email;
            customer.Street = customerdto.Street;
            customer.City = customerdto.City;
            customer.State = customerdto.State;
            customer.Zip_code = customerdto.Zip_code;
            if (!_services.IsEmailValid(customer.Email))
                return BadRequest("Email Not Valid !");
            await _services.Update(customer);
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _services.GetById(id); 
            if (_services.IsEmpty())
                return NotFound($"NotFound Any Customer With Id{id} !");
           await _services.Delete(customer);
            return Ok(customer);
        }
    }
}
