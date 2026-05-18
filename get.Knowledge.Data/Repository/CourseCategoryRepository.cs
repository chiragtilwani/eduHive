using Dapper;
using DataStore.Abstraction.Models;
using DataStore.Abstraction.Repository;
using DataStore.Implementation.Models;
using System.Data;

namespace DataStore.Implementation.Repository
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly IDbConnection _dbConnection;
        public CourseCategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<ICourseCategory>> GetAllAsync()
        {
            var sql = "SELECT * FROM CourseCategory;";
            var result = await _dbConnection.QueryAsync<CourseCategory>(sql);
            return result;
        }

        public async Task<ICourseCategory?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM CourseCategory WHERE CategoryId = @Id;";
            var result = await _dbConnection.QueryFirstOrDefaultAsync<CourseCategory>(sql, new { Id = id });

            return result;
        }
    }
}
