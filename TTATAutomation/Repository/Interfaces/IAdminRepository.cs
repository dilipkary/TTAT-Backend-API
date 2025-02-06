using System.Linq.Expressions;
using TTATAutomation.Models;

namespace TTATAutomation.Repositories.Interfaces
{
    public interface IAdminRepository : IRepository<Admin>
{
    Task<Admin> GetAdminDetailsAsync(Guid adminId);  // Specific to Admin
}

}