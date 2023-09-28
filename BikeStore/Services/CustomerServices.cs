using BikeStore.DTOS;
using BikeStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ApplicationDbContext _context;

        public CustomerServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            return await _context.Customers
                .Include(c=>c.Orders)
                   .Select(c => new CustomerDto
                   {
                       Customer_id = c.Customer_id,
                       Customer_name = c.Customer_name,
                       Phone = c.Phone,
                       Email = c.Email,
                       Street = c.Street,
                       City = c.City,
                       State = c.State,
                       Zip_code = c.Zip_code
                   }).ToListAsync();
        }
        public async Task<Customer> GetById(int id)
        {
        
            return await _context.Customers
                 .SingleOrDefaultAsync(c => c.Customer_id == id);
        }
        public async Task<Customer> Add(Customer Customer)
        {
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();
            return Customer;
        }
        public async Task<Customer> Update(Customer Customer)
        {
            _context.Customers.Update(Customer);
            await _context.SaveChangesAsync();
            return Customer;
        }
        public async Task<Customer> Delete(Customer Customer)
        {
            _context.Customers.Remove(Customer);
            await _context.SaveChangesAsync();
            return Customer;
        }
        public bool IsEmpty()
        {
            return !_context.Customers.Any();
        }
        public bool IsEmailValid(string email)
        {
            var e = new EmailAddressAttribute();
            return e.IsValid(email);
        }
      
    }
}
