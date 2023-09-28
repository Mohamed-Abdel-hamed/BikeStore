using BikeStore.DTOS;
using BikeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Services
{
    public class BrandServices : IBrandServices
    {
        private readonly ApplicationDbContext _context;

        public BrandServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await _context.Brands.
                Include(b=>b.Order_items)
                .Select(b => new Brand
            {
                Brand_id=b.Brand_id,
                Brand_name=b.Brand_name    
            }).ToListAsync();
        }
        public async Task<Brand> GetById(int id)
        {
            return await _context.Brands
                .SingleOrDefaultAsync(b=>b.Brand_id==id);
        }
        public async Task<Brand> Add(Brand Brand)
        {
            _context.Brands.Add(Brand);
            await _context.SaveChangesAsync();
            return Brand;
        }
        public async Task<Brand> Update(Brand Brand)
        {
            _context.Brands.Update(Brand);
            await _context.SaveChangesAsync();
            return Brand;
        }
        public async Task<Brand> Delete(Brand Brand)
        {
            _context.Brands.Remove(Brand);
            await _context.SaveChangesAsync();
            return Brand;
        }  
    }
}
