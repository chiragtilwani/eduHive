namespace DataStore.Implementation.DTOs
{
    public interface ICourseDTO
    {
        int CourseId { get; set; }
        string Title { get; set; }
        string? Description { get; set; }
        decimal Price { get; set; }
        string CourseType { get; set; }
        int SeatsAvailable { get; set; }
        decimal Duration { get; set; }
        string InstructorDisplayName { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Category { get; set; }
        IUserRatingForCourseDTO UserRating { get; set; }
    }
}
