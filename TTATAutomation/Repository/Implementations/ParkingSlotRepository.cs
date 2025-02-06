using Microsoft.EntityFrameworkCore;
using TTATAutomation.Data;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;

namespace TTATAutomation.Repositories.Implementations
{
    public class ParkingSlotRepository : Repository<ParkingSlot>, IParkingSlotRepository
    {
        private readonly AppDbContext _context;
        public ParkingSlotRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParkingSlot>> GetAvailableParkingSlotsAsync()
        {
            return await _context.Set<ParkingSlot>()
                                 .Where(p => !p.IsOccupied)
                                 .ToListAsync();
        }
        // ✅ Count of used (occupied) slots
        public async Task<int> GetUsedSlotsCountAsync()
        {
            return await _context.ParkingSlots.CountAsync(slot => slot.IsOccupied);
        }

        // ✅ Count of unused (available) slots
        public async Task<int> GetUnusedSlotsCountAsync()
        {
            return await _context.ParkingSlots.CountAsync(slot => !slot.IsOccupied);
        }
    }


}