using BikeStore.DTOS;
using BikeStore.Models;

namespace BikeStore.Services
{
    public interface IStaffServices
    {
        Task<IEnumerable<StaffDto>> GetAll();
        Task<Staff> GetById(int id);
        Task<Staff> Add(Staff staff);
        Task<Staff> Update(Staff staff);
        Task<Staff> Delete(Staff staff);
        bool IsEmpty();
    }
}
