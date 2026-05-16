namespace DataStore.Implementation.DTOs
{
    public class UserRatingForCourseDTO : IUserRatingForCourseDTO
    {
        public decimal AverageRating { get; set; }
        public int TotalRatings { get; set; }

    }
}
