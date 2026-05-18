using DataStore.Abstraction.Models;

namespace DataStore.Implementation.Models
{
    internal class SessionDetails : ISessionDetails
    {
        public int SessionId { get; set; }
        public int CourseId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; } = String.Empty;
        public required string VideoUrl { get; set; }
        public int VideoOrder { get; set; }
    }
}
