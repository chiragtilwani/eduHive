using DataStore.Abstraction.Models;

namespace DataStore.Implementation.Models
{
    public class Course : ICourse
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string CourseType { get; set; }
        public int SeatsAvailable { get; set; }
        public decimal Duration { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
