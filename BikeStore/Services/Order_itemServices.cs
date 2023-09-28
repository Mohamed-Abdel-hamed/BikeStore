using BikeStore.DTOS;
using BikeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Services
{
    public class Order_itemServices : IOrder_itemServices
    {
        private readonly ApplicationDbContext _context;

        public Order_itemServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order_item> Add(Order_item order_item)
        {
            await _context.Order_items.AddAsync(order_item);
            await _context.SaveChangesAsync();  
            return order_item;
        }

        public async Task<Order_item> Delete(Order_item order_item)
        {
             _context.Order_items.Remove(order_item);
            await _context.SaveChangesAsync();
            return order_item;
        }

        public async Task<IEnumerable<Order_itemDto>> GetAll()
        {
            return await _context.Order_items
                .Select(order_item => new Order_itemDto
                {
                    Item_id = order_item.Item_id,
                    Order_id = order_item.Order_id,
                    Product_id = order_item.Product_id,
                    Quantity = order_item.Quantity,
                    List_price = order_item.List_price,
                    Descount = order_item.Descount,
                    Product_name = order_item.Product.Product_name
                }).ToListAsync();
        }
  

        public async Task<Order_item> GetById(int id)
        {
            return await _context.Order_items
                .SingleOrDefaultAsync(order_item=>order_item.Item_id == id);

        }

        public bool IsEmpty()
        {
            return !_context.Order_items.Any();
        }

        public async Task<Order_item> Update(Order_item order_item)
        {
            _context.Order_items.Update(order_item);
            await _context.SaveChangesAsync();
            return order_item;
        }
    }
}
