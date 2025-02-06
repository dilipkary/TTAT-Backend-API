using System;
using System.ComponentModel.DataAnnotations;

namespace TTATAutomation.Models
{
    public class AuditLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [Required]
        public string LogLevel { get; set; } // INFO, WARNING, ERROR

        [Required]
        public string Message { get; set; }

        public string? Exception { get; set; } // Stack trace or exception details

        public string? Source { get; set; } // Controller or Service where error occurred
    }
}