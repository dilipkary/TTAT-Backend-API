using Microsoft.EntityFrameworkCore;
using TTATAutomation.Data;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;

namespace TTATAutomation.Repositories.Implementations
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
{
    private readonly AppDbContext _context;
    public AdminRepository(AppDbContext context) : base(context) {
        _context = context;
    }

    public async Task<Admin> GetAdminDetailsAsync(Guid adminId)
    {
        return null; //await _context.Set<Admin>()
     //                        .FirstOrDefaultAsync(a => a.Id == adminId);
    }
}
}