using System.ComponentModel.DataAnnotations;

namespace TTATAutomation.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
    }
}
