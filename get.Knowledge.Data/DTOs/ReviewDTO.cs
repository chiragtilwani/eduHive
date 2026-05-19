using DataStore.Abstraction.DTOs;
using System.ComponentModel.DataAnnotations;

namespace DataStore.Implementation.DTOs
{
    public class ReviewDTO : IReviewDTO
    {
        public int ReviewId { get; set; }
        [Required]
        public required string DisplayName { get; set; }
        public decimal Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
