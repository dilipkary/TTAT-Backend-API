using Microsoft.EntityFrameworkCore;
using TTATAutomation.Data;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;

namespace TTATAutomation.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Set<User>()
                                 .FirstOrDefaultAsync(u => u.Username == username)!;
        }

        public async Task<User?> GetByEmailAsync(string username)
        {
            var user = await _context.Set<User>()
                                 .FirstOrDefaultAsync(u => u.Email == username || u.Username == username);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}