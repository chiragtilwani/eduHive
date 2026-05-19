namespace DataStore.Abstraction.DTOs
{
    public interface ISessionDetailsDTO
    {
        int SessionId { get; set; }
        string Title { get; set; }
        string? Description { get; set; }
        string VideoUrl { get; set; }
        int VideoOrder { get; set; }
    }
}
