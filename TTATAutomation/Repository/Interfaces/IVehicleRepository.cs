using System.Linq.Expressions;
using TTATAutomation.Models;

namespace TTATAutomation.Repositories.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<Vehicle?> GetByRFIDAsync(string rfidTag);  // Specific to Vehicle
    }
}

