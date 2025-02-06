using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTATAutomation.Models;

namespace TTATAutomation.Services
{
    public interface IParkingSlotService
    {
        Task<IEnumerable<ParkingSlot>> GetAllParkingSlotsAsync();
        Task<ParkingSlot> GetParkingSlotByIdAsync(Guid id);
        Task<IEnumerable<ParkingSlot>> SearchParkingSlotsAsync(string search);
        Task<bool> AddParkingSlotAsync(ParkingSlot parkingSlot);
        Task<bool> AssignRFIDAsync(Guid parkingSlotId, Guid rfid);
        Task<bool> UpdateParkingSlotAsync(ParkingSlot parkingSlot);
        Task<bool> DeleteParkingSlotAsync(Guid id);
        Task<ParkingSlot> GetParkingSlotByRFID(Guid rfidTag);
        Task<int> GetParkingSlotCountAsync();
        Task<List<ParkingSlot>> GetAvailableSlotsAsync(); // Fixed return type
        Task<int> GetUsedSlotsCountAsync();
        Task<int> GetUnusedSlotsCountAsync();
    }
}