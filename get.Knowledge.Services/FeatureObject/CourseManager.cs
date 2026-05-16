using DataStore.Abstraction.Repository;
using DataStore.Implementation.DTOs;
using FeatureObjects.Abstraction.AbstractObject;
using System.Net;
using static DataStore.Abstraction.Utilities.Constants;
using static DataStore.Abstraction.Utilities.CustomExceptions;

namespace FeatureObjects.Implementaion.FeatureObject
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<IEnumerable<ICourseDTO>> GetAll()
        {
            return await _courseRepository.GetAll();
        }

        public async Task<ICourseDTO> GetById(int id)
        {
            var result = await _courseRepository.GetById(id);
            if (result == null)
            {
                string errorMessage = String.Format(CommonErrorMessages.NotFound, "Course", id);
                throw new APIException(errorMessage,HttpStatusCode.NotFound);
            }

            return result;
        }
    }
}
