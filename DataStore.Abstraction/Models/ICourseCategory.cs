namespace DataStore.Abstraction.Models
{
    public interface ICourseCategory
    {
        int CategoryId { get; set; }
        string? CategoryName { get; set; }
        string? Description { get; set; }
    }
}
