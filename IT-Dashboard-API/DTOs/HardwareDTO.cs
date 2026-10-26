namespace IT_Dashboard_API.DTOs
{
    public record HardwareDTO(
        string AssetTag,
        string DeviceType,
        string Status,
        int? AssignedToUserId
    );
}
