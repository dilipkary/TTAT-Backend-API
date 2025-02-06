using System;
using System.ComponentModel.DataAnnotations;

namespace TTATAutomation.Models
{
    public class GateTransaction
    {
        [Key]
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public string Status { get; set; } // "IN", "OUT", "LOADING", "UNLOADING"
    }
}