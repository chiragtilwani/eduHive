using DataStore.Implementation.DTOs;

namespace FeatureObjects.Abstraction.AbstractObject
{
    public interface ICourseManager
    {
        Task<IEnumerable<ICourseDTO>> GetAllAsync();
        Task<ICourseDTO> GetByIdAsync(int id);
    }
}
