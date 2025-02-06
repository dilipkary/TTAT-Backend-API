using Microsoft.EntityFrameworkCore;
using TTATAutomation.Data;
using TTATAutomation.Helpers;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;

namespace TTATAutomation.Repositories.Implementations
{
    public class WeighmentRepository : Repository<Weighment>, IWeighmentRepository
    {
        private readonly AppDbContext _context;

        public WeighmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Weighment?> GetWeighmentByVIDAsync(Guid VId)
        {
            return await _context.Set<Weighment>()
                                 .OrderByDescending(w => w.EntryTimestamp)
                                 .FirstOrDefaultAsync(w => w.VehicleId == VId && w.Status != WeighmentStatus.Approved);
        }

        public async Task<IEnumerable<Weighment>> GetAllWeighmentsAsync()
        {
            return await _context.Set<Weighment>().ToListAsync();
        }

        // public async Task<bool> RecordFirstWeighmentAsync(Weighment transaction)
        // {
        //     await _context.Set<Weighment>().AddAsync(transaction);
        //     return await _context.SaveChangesAsync() > 0;
        // }

        public async Task<bool> RecordSecondWeighmentAsync(Weighment wt)
        {

            wt.Status = WeighmentStatus.SecondWeighmentRecorded;

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<Weighment?> GetWeighmentActiveByVidAsync(Guid Vid)
        {
            return await _context.Set<Weighment>()
                                 .FirstOrDefaultAsync(w => w.VehicleId == Vid && w.IsActive == true);
        }

        public async Task<bool> DeleteWeighmentAsync(Guid VId)
        {
            var weighment = await _context.Set<Weighment>().FirstOrDefaultAsync(w => w.VehicleId == VId);
            if (weighment == null) return false;

            _context.Set<Weighment>().Remove(weighment);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}