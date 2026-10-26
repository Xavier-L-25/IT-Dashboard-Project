using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Dashboard_API.Models
{
    public class TicketNoteModel : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public virtual TicketModel Ticket { get; set; } = null!;
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserModel User { get; set; } = null!;
        public required string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
