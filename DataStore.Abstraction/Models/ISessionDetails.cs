namespace DataStore.Abstraction.Models
{
    public interface ISessionDetails
    {
        int SessionId { get; set; }
        int CourseId { get; set; }
        string Title { get; set; }
        string? Description { get; set; }
        string VideoUrl { get; set; }
        int VideoOrder { get; set; }
    }
}
