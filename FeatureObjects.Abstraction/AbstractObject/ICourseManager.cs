using DataStore.Abstraction.Enums;
using DataStore.Implementation.DTOs;

namespace FeatureObjects.Abstraction.AbstractObject
{
    public interface ICourseManager
    {
        Task<IEnumerable<ICourseDTO>> GetAllAsync(CourseCategoryEnum? categoryId = null);
        Task<ICourseDTO> GetByIdAsync(int id);
    }
}
