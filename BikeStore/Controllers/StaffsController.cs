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
    public class StaffsController : ControllerBase
    {
        private readonly IStaffServices _service;

        public StaffsController( IStaffServices service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staff = await _service.GetAll();
            if (_service.IsEmpty())
                return NotFound("NotFound");
            return Ok(staff);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var staff = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound("NotFound");
            return Ok(staff);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StaffDto staffdto)
        {
            var staff = new Staff
            {
                Staff_name = staffdto.Staff_name,
                Email = staffdto.Email,
                Phone = staffdto.Phone,
                Active = staffdto.Active,
                Store_id = staffdto.Store_id,
                Manager_id = staffdto.Manager_id,
            };
            await _service.Add(staff);
            return Ok(staff);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] StaffDto staffdto)
        {
            var staff = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound("NotFound");
            staff.Staff_name = staffdto.Staff_name;
            staff.Email = staffdto.Email;
            staff.Phone = staffdto.Phone;
            staff.Active = staffdto.Active;
            staff.Store_id = staffdto.Store_id;
            staff.Manager_id = staffdto.Manager_id;
            await _service.Update(staff);
            return Ok(staff);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var staff = await _service.GetById(id);
            if (_service.IsEmpty())
                return NotFound("NotFound");
            await _service.Delete(staff);
            return Ok(staff);
        }
    }
}
