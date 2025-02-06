using TTATAutomation.Models;

namespace TTATAutomation.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(Guid id);
        Task<IEnumerable<Vehicle>> SearchVehiclesAsync(string search);
        Task RegisterVehicleAsync(Vehicle vehicle);
        Task<bool> AssignRFIDAsync(Guid vehicleId, string rfid);
        Task<bool> UpdateVehicleAsync(Vehicle vehicle);
        Task<bool> DeleteVehicleAsync(Guid id);
        Task<Vehicle?> GetVehicleByRFID(string rfidTag);
        Task<int> GetVehicleCountAsync();
    }
}
