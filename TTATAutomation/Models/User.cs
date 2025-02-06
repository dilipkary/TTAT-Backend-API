using System;

namespace TTATAutomation.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; }

        public User()
        {
            Username = "";
            Password = "";
            Role = "";
            Email = "";
        }
    }
}
