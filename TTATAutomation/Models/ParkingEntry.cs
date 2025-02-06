using System.ComponentModel.DataAnnotations;

namespace TTATAutomation.Models
{
    public class ParkingLog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid VehicleID { get; set; }
        public bool IsAvailable { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public string SlotId { get; set; }
        public DateTime ParkedAt { get; set; }
        public DateTime? LeftAt { get; set; }
        public TimeSpan? TurnArroundTime
        {
            get
            {
                return LeftAt.HasValue ? (TimeSpan?)(LeftAt.Value - ParkedAt) : null;
            }
        }
    }
}
