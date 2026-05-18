using Dapper;
using DataStore.Abstraction.Repository;
using DataStore.Implementation.DTOs;
using DataStore.Implementation.Models;
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
        public async Task<IEnumerable<ICourseDTO>> GetAllAsync()

        {
            const string sql = @"
                                SELECT c.CourseId, c.Title, c.Description,
                                    c.Price, c.CourseType, c.SeatsAvailable,
                                    c.Duration, u.DisplayName AS InstructorDisplayName,
                                    c.StartDate, c.EndDate, cc.CategoryName AS Category,
                                    ISNULL(AVG(r.Rating),0) AS AverageRating, COUNT(DISTINCT r.ReviewId) AS TotalRatings
                                FROM Course c
                                LEFT JOIN Instructor i ON c.InstructorId = i.InstructorId
                                LEFT JOIN UserProfile u ON i.UserId = u.UserId
                                LEFT JOIN CourseCategory cc ON c.CategoryId = cc.CategoryId
                                LEFT JOIN Review r ON c.CourseId = r.CourseId
                                GROUP BY c.CourseId, c.Title, c.Description, c.Price,
                                         c.CourseType, c.SeatsAvailable, c.Duration, u.DisplayName,
                                         c.StartDate, c.EndDate, cc.CategoryName;";

            var result = await _dbConnection.QueryAsync<CourseDTO, UserRatingForCourseDTO, CourseDTO>(sql, (course, rating) =>
            {
                //course. = rating;
                return course;
            }, splitOn: "AverageRating");

            return result;
        }

        public async Task<ICourseDTO?> GetByIdAsync(int id)
        {
            var courseDictionary = new Dictionary<int, CourseDTO>();
            var result = await _dbConnection.QueryAsync<CourseDTO, Review, SessionDetails, CourseDTO>(StoredProcedures.GetCourseById, (course, review, session) =>
            {
                if (!courseDictionary.TryGetValue(course.CourseId, out var currentCourse))
                {
                    currentCourse = course;
                    courseDictionary.Add(course.CourseId, currentCourse);
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
            }, new { Id = id }, splitOn: "ReviewId,SessionId", commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
