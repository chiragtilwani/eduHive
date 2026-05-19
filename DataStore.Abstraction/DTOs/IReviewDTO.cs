namespace DataStore.Abstraction.DTOs
{
    public interface IReviewDTO
    {
        int ReviewId { get; set; }
        string DisplayName { get; set; }
        decimal Rating { get; set; }
        string? Comment { get; set; }
        DateTime ReviewDate { get; set; }
    }
}
