namespace DataStore.Implementation.DTOs
{
    public interface IUserRatingForCourseDTO
    {
        decimal AverageRating { get; set; }
        int TotalRatings { get; set; }

    }
}
