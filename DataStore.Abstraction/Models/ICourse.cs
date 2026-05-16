namespace DataStore.Abstraction.Models
{
    public interface ICourse
    {
        int CourseId { get; set; }
        string Title { get; set; }
        string? Description { get; set; }
        decimal Price { get; set; }
        string CourseType { get; set; }
        int SeatsAvailable { get; set; }
        decimal Duration { get; set; }
        int CategoryId { get; set; }
        int InstructorId { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
