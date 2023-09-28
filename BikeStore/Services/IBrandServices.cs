using BikeStore.DTOS;
using BikeStore.Models;

namespace BikeStore.Services
{
    public interface IBrandServices
    {
        Task<IEnumerable<Brand>> GetAll();
        Task<Brand> GetById(int id);
        Task<Brand> Add(Brand Brand);
        Task<Brand> Update(Brand Brand);
        Task<Brand> Delete(Brand Brand);
    }
}
