using System.Linq.Expressions;
using TTATAutomation.Models;

namespace TTATAutomation.Repositories.Interfaces
{
    public interface IParkingRepository : IRepository<ParkingLog>
    {
        Task<IEnumerable<ParkingLog>> GetAvailableParkingAsync();  // Specific to Parking
        Task<ParkingLog?> GetActiveLogByVIDAsync(Guid rfidTag);
    }

}