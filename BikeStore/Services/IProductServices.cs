using BikeStore.DTOS;
using BikeStore.Models;

namespace BikeStore.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<Product> GetById(int id);
        Task<IEnumerable<ProductDto>> Search(string productname);
        Task<IEnumerable<ProductDto>> ProductByBrand(string brandname);
        Task<IEnumerable<ProductDto>> ProductByDescendigOrder();
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(Product product);
        bool IsEmpty();

    }
}
