using DataStore.Abstraction.Models;

namespace DataStore.Implementation.Models
{
    public class Review : IReview
    {
        public int ReviewId { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
