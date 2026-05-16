using Dapper;
using DataStore.Abstraction.Repository;
using DataStore.Implementation.DTOs;
using System.Data;

namespace DataStore.Implementation.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbConnection _dbConnection;

        public CourseRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<ICourseDTO>> GetAll()

        {
            const string sql = @"
                                SELECT c.CourseId, c.Title, c.Description,
                                    c.Price, c.CourseType, c.SeatsAvailable,
                                    c.Duration, u.DisplayName AS InstructorDisplayName,
                                    c.StartDate, c.EndDate, cc.CategoryName AS Category,
                                    ISNULL(AVG(r.Rating),0) AS AverageRating, COUNT(r.Rating) AS TotalRatings
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
                course.UserRating = rating;
                return course;
            }, splitOn: "AverageRating");

            return result;
        }

        public async Task<ICourseDTO> GetById(int id)
        {
            const string sql = @"
                                SELECT c.CourseId, c.Title, c.Description,
                                    c.Price, c.CourseType, c.SeatsAvailable,
                                    c.Duration, u.DisplayName AS InstructorDisplayName,
                                    c.StartDate, c.EndDate, cc.CategoryName AS Category,
                                    ISNULL(AVG(r.Rating),0) AS AverageRating, COUNT(r.Rating) AS TotalRatings
                                FROM Course c
                                LEFT JOIN Instructor i ON c.InstructorId = i.InstructorId
                                LEFT JOIN UserProfile u ON i.UserId = u.UserId
                                LEFT JOIN CourseCategory cc ON c.CategoryId = cc.CategoryId
                                LEFT JOIN Review r ON c.CourseId = r.CourseId
                                WHERE c.CourseId = @Id
                                GROUP BY c.CourseId, c.Title, c.Description, c.Price,
                                         c.CourseType, c.SeatsAvailable, c.Duration, u.DisplayName,
                                         c.StartDate, c.EndDate, cc.CategoryName;";
            var result = await _dbConnection.QueryAsync<CourseDTO, UserRatingForCourseDTO, CourseDTO>(sql, (course, userRating) =>
            {
                course.UserRating = userRating;
                return course;
            }, new { Id = id }, splitOn: "AverageRating");

            return result.FirstOrDefault();
        }
    }
}
