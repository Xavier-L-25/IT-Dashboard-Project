namespace IT_Dashboard_API.DTOs
{
    public record TicketNoteDTO(
        int UserId,
        string Note,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
