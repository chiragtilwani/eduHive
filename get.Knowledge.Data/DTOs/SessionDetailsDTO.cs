using DataStore.Abstraction.DTOs;
using System.ComponentModel.DataAnnotations;

namespace DataStore.Implementation.DTOs
{
    public class SessionDetailsDTO : ISessionDetailsDTO
    {
        public int SessionId { get; set; }
        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string VideoUrl { get; set; }
        public int VideoOrder { get; set; }
    }
}
