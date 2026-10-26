namespace IT_Dashboard_API.DTOs
{
    public record UserDTO(
        string FirstName,
        string LastName,
        string Email,
        string Role
    );
}
