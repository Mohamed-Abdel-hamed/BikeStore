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
    public class CategoreisController : ControllerBase
    {
        private readonly ICategoryServices _services;
        public CategoreisController( ICategoryServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _services.GetAll();
            if (!category.Any())
                return NotFound(value: " Not Found Any Category!");
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var category = await _services.GetById(id);
            if (category == null)
                return NotFound(value:$" Not Found Category With Id {id}!");
            return Ok(category);
        }
        [HttpGet(" Search")]
      public async Task<IActionResult> Search(string name)
        {
            var category = await _services.Search(name);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryDto category)
        {
            var newcategory = new Category
            {
                Category_name = category.Category_name
            };
           await _services.Add(newcategory);
            return Ok(newcategory);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CategoryDto Updatecategory)
        {
            var category = await _services.GetById(id);
            if (category == null)
                return NotFound(value: $" Not Found Category With Id {id}!");
            category.Category_name = Updatecategory.Category_name;
            await _services.Update(category);
            return Ok(category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _services.GetById(id);
            if (category == null)
                return NotFound(value: $" Not Found Category With Id {id}!");
            await _services.Delete(category);
            return Ok(category);
        }
    }
}
