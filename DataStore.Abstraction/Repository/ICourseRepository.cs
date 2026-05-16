using DataStore.Implementation.DTOs;

namespace DataStore.Abstraction.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<ICourseDTO>> GetAll();
        Task<ICourseDTO> GetById(int id);

    }
}
