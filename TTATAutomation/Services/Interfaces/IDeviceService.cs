using TTATAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTATAutomation.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<Device> GetDeviceByIdAsync(Guid id);
        Task AddDeviceAsync(Device device);
        Task<bool> UpdateDeviceAsync(Device device);
        Task<bool> DeleteDeviceAsync(Guid id);
    }
}