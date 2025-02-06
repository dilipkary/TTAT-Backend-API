using Microsoft.EntityFrameworkCore;
using TTATAutomation.Data;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;

namespace TTATAutomation.Repositories.Implementations
{
    public class GateTransactionRepository : Repository<GateTransaction>, IGateTransactionRepository
    {
        private readonly AppDbContext _context;

        public GateTransactionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GateTransaction?> GetByVidAsync(Guid VId)
        {
            return await _context.Set<GateTransaction>()
                                 .FirstOrDefaultAsync(t => t.VehicleId == VId && t.ExitTime == null);
        }

        public async Task<bool> RegisterEntryAsync(GateTransaction transaction)
        {
            await _context.Set<GateTransaction>().AddAsync(transaction);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RegisterExitAsync(Guid vehicleId)
        {
            var transaction = await _context.Set<GateTransaction>()
                                            .FirstOrDefaultAsync(t => t.VehicleId == vehicleId && t.ExitTime == null);
            if (transaction == null) return false;

            transaction.ExitTime = DateTime.UtcNow;
            transaction.Status = "OUT";

            return await _context.SaveChangesAsync() > 0;
        }
    }
}