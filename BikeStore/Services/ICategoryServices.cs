using BikeStore.DTOS;
using BikeStore.Models;

namespace BikeStore.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<Category> GetById(int id);
        Task<IEnumerable<CategoryDto>> Search(string name);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(Category category);
       
    }
}
