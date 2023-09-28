using BikeStore.DTOS;
using BikeStore.Models;

namespace BikeStore.Services
{
    public interface IOrder_itemServices
    {
        Task<IEnumerable<Order_itemDto>> GetAll();
        Task<Order_item> GetById(int id);
        Task<Order_item> Add(Order_item category);
        Task<Order_item> Update(Order_item category);
        Task<Order_item> Delete(Order_item category);
        bool IsEmpty();
    }
}
