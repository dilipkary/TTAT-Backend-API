using Microsoft.EntityFrameworkCore;
using TTATAutomation.Data;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;

namespace TTATAutomation.Repositories.Implementations
{
    public class ParkingRepository : Repository<ParkingLog>, IParkingRepository
    {
        private readonly AppDbContext _context;
        public ParkingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParkingLog>> GetAvailableParkingAsync()
        {
            return await _context.Set<ParkingLog>()
                                 .Where(p => p.IsAvailable)
                                 .ToListAsync();
        }
        /// <summary>
        /// Retrieves the active parking log entry where the vehicle has entered but has not exited yet.
        /// </summary>
        /// <param name="rfidTag">RFID tag of the vehicle</param>
        /// <returns>Active parking log if found, otherwise null.</returns>
        public async Task<ParkingLog?> GetActiveLogByVIDAsync(Guid VID)
        {
            var parkingLog = await _context.ParkingLogs
                .Where(log => log.VehicleID == VID && log.IsAvailable) // Get the latest entry
                .FirstOrDefaultAsync();

            return parkingLog;
        }

    }


}