using DataStore.Abstraction.Models;
using DataStore.Abstraction.Repository;
using FeatureObjects.Abstraction.AbstractObject;
using System.Net;
using static DataStore.Abstraction.Utilities.Constants;
using static DataStore.Abstraction.Utilities.CustomExceptions;

namespace FeatureObjects.Implementaion.FeatureObject
{
    public class CourseCategoryManager : ICourseCategoryManager
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        public CourseCategoryManager(ICourseCategoryRepository courseCategoryRepository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }
        public async Task<IEnumerable<ICourseCategory>> GetAllAsync()
        {
            return await _courseCategoryRepository.GetAllAsync();
        }

        public async Task<ICourseCategory> GetByIdAsync(int id)
        {
            var result = await _courseCategoryRepository.GetByIdAsync(id);
            if (result == null)
            {
                string errorMessage = String.Format(CommonErrorMessages.NotFound, "CourseCategory", id);
                throw new APIException(errorMessage, HttpStatusCode.NotFound);
            }
            return result;
        }
    }
}
