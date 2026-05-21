using Dapper;
using DataStore.Abstraction.Enums;
using DataStore.Abstraction.Repository;
using DataStore.Implementation.DTOs;
using System.Data;
using static DataStore.Abstraction.Utilities.Constants;

namespace DataStore.Implementation.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbConnection _dbConnection;

        public CourseRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<ICourseDTO>> GetAllAsync(CourseCategoryEnum? categoryId = null)
        {
            Dictionary<int, CourseDTO> courseDictionary = await GetAllCoursesDictionaryAsync(categoryId: categoryId);

            return courseDictionary.Values;
        }

        public async Task<ICourseDTO?> GetByIdAsync(int id)
        {
            Dictionary<int, CourseDTO> courseDictionary = await GetAllCoursesDictionaryAsync(id);

            return courseDictionary.Values.FirstOrDefault();
        }

        #region Private Methods
        private async Task<Dictionary<int, CourseDTO>> GetAllCoursesDictionaryAsync(int courseId = 0, CourseCategoryEnum? categoryId = null)
        {
            var courseDictionary = new Dictionary<int, CourseDTO>();

            var result = await _dbConnection.QueryAsync<CourseDTO, ReviewDTO, SessionDetailsDTO, CourseDTO>(StoredProcedures.GetAllCourses, (course, review, session) =>
            {
                // As Query is having one-to-many relationship so there would be definitely redundant data to avoid returning duplicate courses courseDictionary is being used here
                if (!courseDictionary.TryGetValue(course.CourseId, out var currentCourse))
                {
                    currentCourse = course;
                    courseDictionary.Add(course.CourseId, course);
                }

                // Add review if it exists and is not already added
                if (review != null && !currentCourse.Reviews.Any(r => r.ReviewId == review.ReviewId))
                {
                    currentCourse.Reviews.Add(review);
                }

                // Add session if it exists and is not already added
                if (session != null && !currentCourse.Sessions.Any(s => s.SessionId == session.SessionId))
                {
                    currentCourse.Sessions.Add(session);
                }

                return currentCourse;
            }, courseId != 0 || categoryId is not null ? new { courseId, categoryId } : null, splitOn: "ReviewId,SessionId", commandType: CommandType.StoredProcedure);

            return courseDictionary;
        }
        #endregion
    }
}
