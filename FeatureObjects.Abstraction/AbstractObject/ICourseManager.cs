using DataStore.Implementation.DTOs;

namespace FeatureObjects.Abstraction.AbstractObject
{
    public interface ICourseManager
    {
        Task<IEnumerable<ICourseDTO>> GetAll();
        Task<ICourseDTO> GetById(int id);
    }
}
