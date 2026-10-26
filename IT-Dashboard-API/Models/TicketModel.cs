using System.ComponentModel.DataAnnotations;

namespace IT_Dashboard_API.Models
{
    public class TicketModel : IAuditableEntity
    {
        [Key]
        public int Id { get; set; } 
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required string Priority { get; set; }
        public required string Status { get; set; }
        public required string SubmittedByUserId { get; set; }
        public string? AssignedToUserId { get; set; }
        public required string AssetId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; } 
    }
}
