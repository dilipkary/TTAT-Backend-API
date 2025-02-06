using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TTATAutomation.Helpers;
namespace TTATAutomation.Models
{
    public class Weighment
    {
        [Key]
        public Guid Id { get; set; } // Unique transaction ID

        [Required]
        public Guid VehicleId { get; set; }  // Vehicle Registration Number (VRN)

        [Required]
        public decimal TareWeight { get; set; }  // Weight of empty vehicle (first weighment)

        public decimal? GrossWeight { get; set; }  // Loaded vehicle weight (second weighment)

        [NotMapped]  // This field is computed, not stored in the database
        public decimal? NetWeight => (GrossWeight.HasValue ? GrossWeight - TareWeight : null);

        [Required]
        public DateTime EntryTimestamp { get; set; }  // Timestamp of first weighment

        public DateTime? ExitTimestamp { get; set; }  // Timestamp of second weighment

        public WeighmentStatus? Status { get; set; }  // Transaction status (e.g., "First Weighment", "Completed")
        public bool IsActive { get; set; } = true;  // Transaction status (e.g., "First Weighment", "Completed")
        // Additional optional fields
        public string? ProductType { get; set; }  // Type of goods
        public string? Company { get; set; }  // Associated company
        public string? DriverName { get; set; }  // Driver details
        public string? Comments { get; set; }  // Additional remarks
    }
}