using System;
using System.ComponentModel.DataAnnotations;

namespace TTATAutomation.Models
{
    public class Device
    {
        [Key]
        public Guid Id { get; set; }
        public string DeviceId { get; set; }

        [Required]
        public string DeviceName { get; set; }

        [Required]
        public string IP { get; set; }

        [Required]
        public int Port { get; set; }

        [Required]
        public string Protocol { get; set; }

        public bool IsActive { get; set; }
    }
}