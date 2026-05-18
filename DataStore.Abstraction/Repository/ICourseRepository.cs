using DataStore.Implementation.DTOs;

namespace DataStore.Abstraction.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<ICourseDTO>> GetAllAsync();
        Task<ICourseDTO?> GetByIdAsync(int id);

    }
}
