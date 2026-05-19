using DataStore.Abstraction.DTOs;
using System.ComponentModel.DataAnnotations;

namespace DataStore.Implementation.DTOs
{
    public class CourseDTO : ICourseDTO
    {
        public int CourseId { get; set; }
        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public required string CourseType { get; set; } = "Online";
        public int SeatsAvailable { get; set; }
        public decimal Duration { get; set; }
        [Required]
        public required string InstructorDisplayName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public required string Category { get; set; }
        public decimal AverageRating { get; set; }
        public int TotalRating { get; set; }
        public List<IReviewDTO> Reviews { get; set; } = new List<IReviewDTO>();
        public List<ISessionDetailsDTO> Sessions { get; set; } = new List<ISessionDetailsDTO>();
    }
}
