using DataStore.Abstraction.Models;

namespace FeatureObjects.Abstraction.AbstractObject
{
    public interface ICourseCategoryManager
    {
        Task<IEnumerable<ICourseCategory>> GetAllAsync();
        Task<ICourseCategory> GetByIdAsync(int id);
    }
}
