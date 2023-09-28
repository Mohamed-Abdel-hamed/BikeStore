using BikeStore.DTOS;
using BikeStore.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _context;
        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
           return await _context.Categories
                .Select(c=>new CategoryDto
                {
                    Category_id=c.Category_id,
                    Category_name=c.Category_name
                 }).ToListAsync();
        }
        public async Task<Category> GetById(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c=>c.Category_id==id);
        }
        public async Task<Category> Add(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Update(Category category)
        {
           _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Delete(Category category)
        {
           _context.Categories.Remove(category);
           await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<CategoryDto>> Search(string name)
        {
            var category = await _context.Categories
                .Where(c => c.Category_name.Contains(name))
                .Select(c=>new CategoryDto
                {
                    Category_id= c.Category_id,
                    Category_name= c.Category_name
                }
                )
            .ToListAsync();
            return category;
        }
    }
}
