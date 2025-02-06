using Microsoft.EntityFrameworkCore;
using TTATAutomation.Models;
using BCrypt.Net;
using TTATAutomation.Helpers;

namespace TTATAutomation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<GateTransaction> GateTransactions { get; set; }
        public DbSet<ParkingLog> ParkingLogs { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weighment> Weighments { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Device> Devices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var defaultUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var defaultVehicleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var defaultSlotId = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var dt = new DateTime(2022, 12, 31, 0, 0, 0, kind: DateTimeKind.Utc);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("Admin@123");
            base.OnModelCreating(modelBuilder);

            // Default User
            //var defaultUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = defaultUserId,
                Username = "Admin",
                Password = hashedPassword, // Use an actual hash
                Role = "Admin",
            });

            // Default Vehicle

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = defaultVehicleId,
                DriverName = "John Doe",
                VehicleNumber = "ABC123",
                DLNo = "DL123",
                RFIDTag = "12345",
                Type = VehicleType.Compact,
                Permit = dt,
                CreatedAt = dt
            });

            modelBuilder.Entity<ParkingSlot>().HasData(new ParkingSlot
            {
                Id = defaultSlotId,
                SlotNumber = "P1",
                IsOccupied = false,
                VehicleID = null,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            });

        }
    }

}
