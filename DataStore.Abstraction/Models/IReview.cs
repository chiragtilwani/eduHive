namespace DataStore.Abstraction.Models
{
    public interface IReview
    {
        int ReviewId { get; set; }
        int CourseId { get; set; }
        int UserId { get; set; }
        decimal Rating { get; set; }
        string? Comment { get; set; }
        DateTime ReviewDate { get; set; }
    }
}
