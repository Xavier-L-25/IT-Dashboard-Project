using System.ComponentModel.DataAnnotations;

namespace IT_Dashboard_API.Models
{
    public class HardwareModel
    {
        [Key]
        public int Id { get; set; }
        public required string AssetTag { get; set; }
        public required string DeviceType { get; set; }
        public required string Status { get; set; }
        public int? AssignedToUserId { get; set; }  
    }
}
