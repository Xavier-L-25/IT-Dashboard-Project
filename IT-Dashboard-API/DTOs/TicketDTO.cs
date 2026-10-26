namespace IT_Dashboard_API.DTOs
{
    public record TicketDTO(
        string Title,
        string Description,
        string Category,
        string Priority,
        string Status,
        string SubmittedByUserId,
        string? AssignedToUserId,
        string AssetId
    );
}