using System.Linq.Expressions;
using TTATAutomation.Models;

namespace TTATAutomation.Repositories.Interfaces
{
    public interface IParkingSlotRepository : IRepository<ParkingSlot>
    {
        Task<IEnumerable<ParkingSlot>> GetAvailableParkingSlotsAsync();  // Specific to Parking
        Task<int> GetUsedSlotsCountAsync();
        Task<int> GetUnusedSlotsCountAsync();
    }

}