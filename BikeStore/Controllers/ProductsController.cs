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
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _service;
        public ProductsController(IProductServices service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var product=await _service.GetAll();
            if(_service.IsEmpty())
                return NotFound();
            return Ok(product);
        }
        [HttpGet("ProductByBrandName")]
        public async Task<IActionResult> ProductByBrandName(string brandname)
        {
            var product=await _service.ProductByBrand(brandname);
            if (_service.IsEmpty())
                return NotFound();
            return Ok(product);
        }
        [HttpGet(" ProductByDescendigOrder")]
        public async Task<IActionResult> ProductByDescendigOrder()
        {
            var product = await _service.ProductByDescendigOrder();
            if (_service.IsEmpty())
                return NotFound();
            return Ok(product);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string productname)
        {
            var product=await _service.Search(productname);
            if (_service.IsEmpty())
                return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto Productdto)
        {
            var product = new Product
            {
                Product_name = Productdto.Product_name,
                Model_year = Productdto.Model_year,
                List_price = Productdto.List_price,
                Brand_id = Productdto.Brand_id,
                Category_id = Productdto.Category_id
            };
            await _service.Add(product);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id, ProductDto Productdto)
        {
            var product=await _service.GetById(id);
            if(_service.IsEmpty()) 
                return NotFound();
            product.Product_name = Productdto.Product_name;
            product.Model_year = Productdto.Model_year;
            product.List_price = Productdto.List_price;
            product.Brand_id = Productdto.Brand_id;
            product.Category_id = Productdto.Category_id;
           await  _service.Update(product);
            
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var product = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound();
          await _service.Delete(product);
            return Ok(product);
        }
        }
}
