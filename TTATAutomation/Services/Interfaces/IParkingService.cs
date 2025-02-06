using System;
using System.Threading.Tasks;
using TTATAutomation.Models;

namespace TTATAutomation.Services.Interfaces
{
    public interface IParkingService
    {
        /// <summary>
        /// Registers a vehicle entry by assigning an available parking slot based on the RFID.
        /// </summary>
        /// <param name="rfidTag">RFID tag of the vehicle</param>
        /// <returns>True if parking entry is registered successfully, otherwise false.</returns>
        Task<bool> RegisterParkingEntryAsync(string rfidTag);

        /// <summary>
        /// Registers a vehicle exit by freeing up the assigned parking slot.
        /// </summary>
        /// <param name="rfidTag">RFID tag of the vehicle</param>
        /// <returns>True if parking exit is registered successfully, otherwise false.</returns>
        Task<bool> RegisterParkingExitAsync(string rfidTag);

        Task<ParkingLog?> GetActiveLogByVIDAsync(Guid rfidTag);
        Task<IEnumerable<ParkingLog>> GetAllParkingLogsAsync();
        Task<ParkingLog> GetParkingLogByIdAsync(Guid id);
        Task<bool> AddParkingLogAsync(ParkingLog parkingLog);
        Task<bool> UpdateParkingLogAsync(ParkingLog parkingLog);
        Task<bool> DeleteParkingLogAsync(Guid id);
        Task<int> GetParkingCountAsync();
    }
}