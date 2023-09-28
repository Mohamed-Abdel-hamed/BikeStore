using BikeStore.DTOS;
using BikeStore.Models;

namespace BikeStore.Services
{
    public interface IOrderServices
    {
        Task<IEnumerable<OrderDto>> GetAll();
        Task<Order> GetById(int id);
        Task<IEnumerable<OrderDto>> GetByDateOrder();
        Task<Order> Add(Order order);
        Task<Order> Update(Order order);
        Task<Order> Delete(Order order);
        bool IsEmpty();
    }
}
