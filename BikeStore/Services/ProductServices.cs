using BikeStore.DTOS;
using BikeStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BikeStore.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;

        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
           await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
            
        }

        public async Task<Product> Delete(Product product)
        {
            _context.Products.Remove(product);
           await _context.SaveChangesAsync();
            return product;

        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await _context.Products
                 .Select(p => new ProductDto
                 {
                     Product_id = p.Product_id,
                     Product_name = p.Product_name,
                     Model_year = p.Model_year,
                     List_price = p.List_price,
                     Brand_id = p.Brand_id,
                     Brand_name=p.Brand.Brand_name,
                     Category_id = p.Category_id,
                     Category_name = p.Category.Category_name
                 }).ToListAsync();
        }
        public async Task<Product> GetById(int id)
        {
            return await  _context.Products
                .Include(p=>p.Brand)
                .Include(p=>p.Category)
                .SingleOrDefaultAsync(p => p.Product_id == id);
   
        }
        public async Task<IEnumerable<ProductDto>> ProductByBrand(string brandname)
        {
            return  await _context.Products
               
                .Select(P => new ProductDto
            {
                Product_name = P.Product_name,
                Model_year = P.Model_year,
                Brand_name = P.Brand.Brand_name
            }). Where(p=>p.Brand_name == brandname)

            .ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> ProductByDescendigOrder()
        {
            var product=_context.Products
                .OrderByDescending(p => p.List_price)
                 .Select(p => new ProductDto
                 {
                     Product_id = p.Product_id,
                     Product_name = p.Product_name,
                     Model_year = p.Model_year,
                     List_price = p.List_price,
                     Brand_id = p.Brand_id,
                     Brand_name = p.Brand.Brand_name,
                     Category_id = p.Category_id,
                     Category_name = p.Category.Category_name
                 });
            return await Task.FromResult(product);
        }
        public async Task<IEnumerable<ProductDto>> Search(string productname)
        {
            return await _context.Products
                 .Where(p => p.Product_name.
                 Contains(productname))
                  .Select(p => new ProductDto
                  {
                      Product_id = p.Product_id,
                      Product_name = p.Product_name,
                      Model_year = p.Model_year,
                      List_price = p.List_price,
                      Brand_id = p.Brand_id,
                      Brand_name = p.Brand.Brand_name,
                      Category_id = p.Category_id,
                      Category_name = p.Category.Category_name
                  }).ToListAsync();
     

        }

        public async Task<Product> Update(Product product)
        {
          _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public bool IsEmpty()
        {
            return !_context.Products.Any();
        }
    }
}
