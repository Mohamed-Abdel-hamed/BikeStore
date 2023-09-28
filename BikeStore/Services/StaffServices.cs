using BikeStore.DTOS;
using BikeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Services
{
    public class StaffServices : IStaffServices
    {
        private readonly ApplicationDbContext _context;

        public StaffServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Staff> Add(Staff staff)
        {
           await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<Staff> Delete(Staff staff)
        {
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<IEnumerable<StaffDto>> GetAll()
        {
            return await _context.Staffs
                .Select(staff=>new StaffDto
                {
                    Staff_id=staff.Staff_id,
                    Staff_name=staff.Staff_name,
                    Email=staff.Email,
                    Phone=staff.Phone,
                    Active=staff.Active,
                    Store_id=staff.Store_id,
                    Store_name=staff.Store.Store_name
                })
                .ToListAsync();
        }

        public async Task<Staff> GetById(int id)
        {
            return await _context.Staffs
               .Select(staff => new Staff
               {
                   Staff_id = staff.Staff_id,
                   Staff_name = staff.Staff_name,
                   Email = staff.Email,
                   Phone = staff.Phone,
                   Active = staff.Active,
                   Store_id = staff.Store_id
                 
               }).SingleOrDefaultAsync(staff => staff.Staff_id == id);
        }

        public bool IsEmpty()
        {
            return !_context.Staffs.Any();
        }

        public async Task<Staff> Update(Staff staff)
        {
            _context.Staffs.Update(staff);
            await _context.SaveChangesAsync();
            return staff;
        }
    }
}
