using BikeStore.DTOS;
using BikeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly ApplicationDbContext _context;

        public OrderServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> Delete(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            return await  _context.Orders
              
                .Select(o => new OrderDto
                {
                    Order_id = o.Order_id,
                    Order_status = o.Order_status,
                    Order_date = o.Order_date,
                    Required_date = o.Required_date,
                    Shipped_date = o.Shipped_date,
                    Store_id = o.Store_id,
                   Customer_name=o.Customer.Customer_name,
                    Staff_name = o.Staff.Staff_name,
                    Staff_id = o.Staff_id,

                }).ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders
                .Select(o => new Order
                {
                    Order_id = o.Order_id,
                    Order_status = o.Order_status,
                    Order_date = o.Order_date,
                    Required_date = o.Required_date,
                    Shipped_date = o.Shipped_date,
                    Customer = o.Customer,
                    Staff = o.Staff
                })
                .SingleOrDefaultAsync(o => o.Order_id == id); 
                
        }

        public async Task<IEnumerable<OrderDto>> GetByDateOrder()
        {
            try { 
            var NewDate=DateTime.Today;
           return await _context.Orders
                 .Select(o => new OrderDto
                 {
                     Order_id = o.Order_id,
                     Order_status = o.Order_status,
                     Order_date = o.Order_date,
                     Required_date = o.Required_date,
                     Shipped_date = o.Shipped_date,
                     Customer_name = o.Customer.Customer_name,
                     Store_name = o.Store.Store_name
                 }).Where(p => DateTime.Parse(p.Order_date) >= NewDate)

            .ToListAsync();
            }
            catch (Exception ex)
            {
                
               return Enumerable.Empty<OrderDto>();
            }

        }
        public async Task<Order> Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public bool IsEmpty()
        {
            return !_context.Orders.Any();
        }
    }
}
