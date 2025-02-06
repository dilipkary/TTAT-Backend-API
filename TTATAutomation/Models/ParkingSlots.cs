using System.ComponentModel.DataAnnotations;

namespace TTATAutomation.Models
{
    public class ParkingSlot
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string SlotNumber { get; set; }
        public bool IsOccupied { get; set; } = false;
        public Guid? VehicleID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime inUseSince { get; set; } = DateTime.Now;

        public DateTime? OccupiedSince { get; set; }
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
        public ParkingSlot()
        {
            SlotNumber = "";
            VehicleID = null;
        }
    }
}
