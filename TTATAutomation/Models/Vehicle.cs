using System.ComponentModel.DataAnnotations;
using TTATAutomation.Helpers;

namespace TTATAutomation.Models
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string VehicleNumber { get; set; }
        [Required]
        public string DriverName { get; set; }
        [Required]
        public string DLNo { get; set; }
        [Required]
        public DateTime Permit { get; set; }
        [Required]
        public VehicleType Type { get; set; }
        public string RFIDTag { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; }
    }
}
