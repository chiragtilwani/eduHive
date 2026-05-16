using DataStore.Abstraction.Models;

namespace DataStore.Abstraction.Repository
{
    public interface ICourseCategoryRepository
    {
        Task<ICourseCategory> GetByIdAsync(int id);
        Task<IEnumerable<ICourseCategory>> GetAllAsync();
    }
}
