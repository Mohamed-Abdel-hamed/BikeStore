using BikeStore.DTOS;
using BikeStore.Models;
using BikeStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        
        private readonly IStoreServices _service;
        public StoresController(IStoreServices service)
        { 
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var store = await _service.GetAll();
           if(_service.IsEmpty())
                return NotFound("NotFound");
            return Ok(store);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var store = await _service.GetById( id);
            if (_service.IsEmpty())
                return NotFound("NotFound");
            return Ok(store);
        }
            [HttpPost]
        public async Task<IActionResult>Create([FromForm]StoreDto storedto)
        {
            var store = new Store
            {
                Store_name = storedto.Store_name,
                Phone = storedto.Phone,
                Email = storedto.Email,
                Zip_code=storedto.Zip_code,
                Street = storedto.Street,
                City = storedto.City,
                State = storedto.State,
            };
            if(_service.IsEmailValid(store.Email))
                return BadRequest("Email Not Valid !");
            await _service.Add(store);
            return Ok(store);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id, [FromForm]StoreDto storedto)
        {
            var store = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound("NotFound");
            store.Store_name = storedto.Store_name;
            store.Phone = storedto.Phone;
            store.Email = storedto.Email;
            store.Zip_code = storedto.Zip_code;
            store.Street = storedto.Street;
            store.City = storedto.City;
            store.State = storedto.State;
            if (_service.IsEmailValid(store.Email))
                return BadRequest("Email Not Valid !");
            await _service.Update(store);
            return Ok(store);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var store = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound("NotFound");

           await _service.Delete(store);
            return Ok(store);
        }
    }
}
