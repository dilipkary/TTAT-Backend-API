using Microsoft.EntityFrameworkCore;
using TTATAutomation.Data;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;

namespace TTATAutomation.Repositories.Implementations
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly AppDbContext _context;
        public VehicleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Vehicle?> GetByRFIDAsync(string rfidTag)
        {
            return await _context.Set<Vehicle>()
                                 .FirstOrDefaultAsync(v => v.RFIDTag == rfidTag)!;
        }
    }

}