using BikeStore.DTOS;
using BikeStore.Models;

namespace BikeStore.Services
{
    public interface IStoreServices
    {
        Task<IEnumerable<StoreDto>> GetAll();
        Task<Store> GetById(int id);
        Task<Store> Add(Store store);
        Task<Store> Update(Store store);
        Task<Store> Delete(Store store);
        bool IsEmpty();
        bool IsEmailValid(string email);
    }
}
