using BikeStore.DTOS;
using BikeStore.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Services
{
    public class StoreServices : IStoreServices
    {
        private readonly ApplicationDbContext _context;

        public StoreServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Store> Add(Store store)
        {
           await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<Store> Delete(Store store)
        {
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return store;

        }

        public async  Task<IEnumerable<StoreDto>> GetAll()

        {
            return await _context.Stores
                 .Select(s => new StoreDto
                 {
                     Store_id = s.Store_id,
                     Store_name = s.Store_name,
                     Phone = s.Phone,
                     Email = s.Email,
                     Street = s.Street,
                     City = s.City,
                     Zip_code = s.Zip_code,
                     Staff_names = s.Staffs
                     .Select(s => s.Staff_name)
                     .ToList()
                 })
                 .ToListAsync();
        }
        public async Task<Store> GetById(int id)
        {
            return await _context.Stores
           .SingleOrDefaultAsync(s=>s.Store_id==id);
        }

        public bool IsEmpty()
        {

            return !_context.Stores.Any();
        }

        public async Task<Store> Update(Store store)
        {
            _context.Stores.Update(store);
            await _context.SaveChangesAsync();
            return store;
        }
        public bool IsEmailValid(string email)
        {
            var e = new EmailAddressAttribute();
            return e.IsValid(email);
        }
    }
}
