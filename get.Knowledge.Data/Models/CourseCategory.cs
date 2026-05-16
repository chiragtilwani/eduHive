using DataStore.Abstraction.Models;

namespace DataStore.Implementation.Models
{
    public class CourseCategory : ICourseCategory
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
