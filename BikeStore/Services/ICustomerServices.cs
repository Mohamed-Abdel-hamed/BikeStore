using BikeStore.DTOS;
using BikeStore.Models;

namespace BikeStore.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerDto>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> Add(Customer Customer);
        Task<Customer> Update(Customer Customer);
        Task<Customer> Delete(Customer Customer);
        bool IsEmpty();
        bool IsEmailValid(string email);
    }
}
