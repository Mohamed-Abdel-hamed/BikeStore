using BikeStore.DTOS;
using BikeStore.Models;
using BikeStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBrandServices _brandServices;
        public BrandsController(ApplicationDbContext context, IBrandServices brandServices)
        {
            _context = context;
            _brandServices = brandServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brand = await _brandServices.GetAll();
            if(brand == null)
                return NotFound("NotFound Any Brand !");
            return Ok(brand);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _brandServices.GetById( id);
            if (brand == null)
                return NotFound($"NotFound Any Brand With Id{id} !");
            return Ok(brand);
        }
        [HttpPost]
        public async Task<IActionResult>Create(BrandDto branddto)
        {
            var brand=new Brand
            {
                Brand_name=branddto.Brand_name
            };
           await _brandServices.Add(brand);
            return Ok(brand);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id, [FromForm]BrandDto branddto)
        {
            var brand = await _brandServices.GetById(id);
            if (brand == null)
                return NotFound($"NotFound Any Brand With Id{id} !");
            brand.Brand_name = branddto.Brand_name;
            await _brandServices.Update(brand);
            return Ok(brand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var brand = await _brandServices.GetById(id);
            if (brand == null)
                return NotFound($"NotFound Any Brand With Id{id} !");
            await _brandServices.Delete(brand);
            return Ok(brand);
        }
    }
}
