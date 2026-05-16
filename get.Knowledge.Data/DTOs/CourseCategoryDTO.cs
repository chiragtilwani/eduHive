namespace DataStore.Implementation.DTOs
{
    public class CourseCategoryDTO : ICourseCategoryDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
