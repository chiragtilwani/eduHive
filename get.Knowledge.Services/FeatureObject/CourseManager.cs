using DataStore.Abstraction.Enums;
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
        public async Task<IEnumerable<ICourseDTO>> GetAllAsync(CourseCategoryEnum? categoryId = null)
        {
            return await _courseRepository.GetAllAsync(categoryId);
        }

        public async Task<ICourseDTO> GetByIdAsync(int id)
        {
            var result = await _courseRepository.GetByIdAsync(id);
            if (result == null)
            {
                string errorMessage = String.Format(CommonErrorMessages.NotFound, "Course", id);
                throw new APIException(errorMessage, HttpStatusCode.NotFound);
            }

            return result;
        }
    }
}
