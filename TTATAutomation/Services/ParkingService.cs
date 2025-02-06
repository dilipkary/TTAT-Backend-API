using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;
using TTATAutomation.Services.Interfaces;

namespace TTATAutomation.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ParkingService> _logger;

        public ParkingService(IUnitOfWork unitOfWork, ILogger<ParkingService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> RegisterParkingEntryAsync(string rfidTag)
        {
            try
            {
                _logger.LogInformation("Registering parking entry for RFID: {RFID}", rfidTag);

                var vehicle = await _unitOfWork.VehicleRepository.GetByRFIDAsync(rfidTag);
                if (vehicle == null)
                {
                    _logger.LogWarning("Vehicle not found for RFID: {RFID}", rfidTag);
                    return false;
                }

                var availableSlot = (await _unitOfWork.ParkingSlotRepository.GetAvailableParkingSlotsAsync()).FirstOrDefault();
                if (availableSlot == null)
                {
                    _logger.LogWarning("No available parking slots found.");
                    return false;
                }

                var parkingLog = new ParkingLog
                {
                    Id = Guid.NewGuid(),
                    VehicleID = vehicle.Id,
                    SlotId = availableSlot.Id.ToString(),
                    IsAvailable = true,
                    ParkedAt = DateTime.UtcNow
                };

                availableSlot.IsOccupied = true;
                availableSlot.VehicleID = vehicle.Id;
                availableSlot.OccupiedSince = DateTime.UtcNow;
                availableSlot.LastUpdatedAt = DateTime.UtcNow;

                await _unitOfWork.ParkingRepository.AddAsync(parkingLog);
                await _unitOfWork.ParkingSlotRepository.UpdateAsync(availableSlot);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("Parking entry registered successfully for vehicle ID: {VehicleId} at slot ID: {SlotId}", vehicle.Id, availableSlot.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while registering parking entry for RFID: {RFID}", rfidTag);
                return false;
            }
        }

        public async Task<bool> RegisterParkingExitAsync(string rfidTag)
        {
            try
            {
                _logger.LogInformation("Registering parking exit for RFID: {RFID}", rfidTag);

                var vehicle = await _unitOfWork.VehicleRepository.GetByRFIDAsync(rfidTag);
                if (vehicle == null)
                {
                    _logger.LogWarning("Vehicle not found for RFID: {RFID}", rfidTag);
                    return false;
                }

                var parkingLog = await _unitOfWork.ParkingRepository.GetActiveLogByVIDAsync(vehicle.Id);
                if (parkingLog == null)
                {
                    _logger.LogWarning("No active parking log found for vehicle ID: {VehicleId}", vehicle.Id);
                    return false;
                }

                var slot = await _unitOfWork.ParkingSlotRepository.GetByIdAsync(Guid.Parse(parkingLog.SlotId));
                if (slot == null)
                {
                    _logger.LogWarning("Parking slot not found for slot ID: {SlotId}", parkingLog.SlotId);
                    return false;
                }

                parkingLog.LeftAt = DateTime.UtcNow;
                parkingLog.IsAvailable = false;

                slot.IsOccupied = false;
                slot.VehicleID = null;
                slot.OccupiedSince = null;
                slot.LastUpdatedAt = DateTime.UtcNow;

                await _unitOfWork.ParkingRepository.UpdateAsync(parkingLog);
                await _unitOfWork.ParkingSlotRepository.UpdateAsync(slot);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("Parking exit registered successfully for vehicle ID: {VehicleId}", vehicle.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while registering parking exit for RFID: {RFID}", rfidTag);
                return false;
            }
        }

        public async Task<ParkingLog> GetParkingLogByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Fetching parking log by ID: {ParkingLogId}", id);
                return await _unitOfWork.ParkingRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching parking log by ID: {ParkingLogId}", id);
                return null!;
            }
        }
        public async Task<int> GetParkingCountAsync()
        {
            return await _unitOfWork.ParkingRepository.GetCountAsync();
        }
        public async Task<IEnumerable<ParkingLog>> GetAllParkingLogsAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all parking logs...");
                var parkingLogs = await _unitOfWork.ParkingRepository.GetAllAsync();
                return parkingLogs.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all parking logs.");
                return Enumerable.Empty<ParkingLog>();
            }
        }

        public async Task<ParkingLog?> GetActiveLogByVIDAsync(Guid vehicleId)
        {
            try
            {
                _logger.LogInformation("Fetching active parking log for vehicle ID: {VehicleId}", vehicleId);
                return await _unitOfWork.ParkingRepository.GetActiveLogByVIDAsync(vehicleId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching active parking log for vehicle ID: {VehicleId}", vehicleId);
                return null;
            }
        }

        public async Task<bool> AddParkingLogAsync(ParkingLog parkingLog)
        {
            try
            {
                _logger.LogInformation("Adding a new parking log...");
                await _unitOfWork.ParkingRepository.AddAsync(parkingLog);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("Parking log added successfully with ID: {ParkingLogId}", parkingLog.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding parking log.");
                return false;
            }
        }

        public async Task<bool> UpdateParkingLogAsync(ParkingLog parkingLog)
        {
            try
            {
                _logger.LogInformation("Updating parking log with ID: {ParkingLogId}", parkingLog.Id);
                await _unitOfWork.ParkingRepository.UpdateAsync(parkingLog);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("Parking log updated successfully with ID: {ParkingLogId}", parkingLog.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating parking log with ID: {ParkingLogId}", parkingLog.Id);
                return false;
            }
        }

        public async Task<bool> DeleteParkingLogAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Deleting parking log with ID: {ParkingLogId}", id);

                var parkingLog = await _unitOfWork.ParkingRepository.GetByIdAsync(id);
                if (parkingLog == null)
                {
                    _logger.LogWarning("Parking log not found with ID: {ParkingLogId}", id);
                    return false;
                }

                await _unitOfWork.ParkingRepository.DeleteAsync(parkingLog);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("Parking log deleted successfully with ID: {ParkingLogId}", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting parking log with ID: {ParkingLogId}", id);
                return false;
            }
        }
    }
}