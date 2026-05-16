namespace DataStore.Implementation.DTOs
{
    public class CourseDTO : ICourseDTO
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string CourseType { get; set; }
        public int SeatsAvailable { get; set; }
        public decimal Duration { get; set; }
        public string InstructorDisplayName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Category { get; set; }
        public IUserRatingForCourseDTO UserRating { get; set; }
    }
}
