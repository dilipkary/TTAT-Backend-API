using System.Linq.Expressions;
using TTATAutomation.Models;

namespace TTATAutomation.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);  // Specific to User
        Task<User?> GetByEmailAsync(string email);  // Specific to User
    }

}