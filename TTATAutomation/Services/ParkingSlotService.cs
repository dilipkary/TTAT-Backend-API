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
    public class ParkingSlotService : IParkingSlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ParkingSlotService> _logger;

        public ParkingSlotService(IUnitOfWork unitOfWork, ILogger<ParkingSlotService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> AddParkingSlotAsync(ParkingSlot slot)
        {
            try
            {
                _logger.LogInformation("Adding new parking slot...");

                slot.Id = Guid.NewGuid();
                slot.IsOccupied = false;
                slot.CreatedAt = DateTime.UtcNow;
                slot.LastUpdatedAt = DateTime.UtcNow;

                await _unitOfWork.ParkingSlotRepository.AddAsync(slot);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("Parking slot added successfully with ID: {SlotId}", slot.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding a parking slot.");
                return false;
            }
        }

        public async Task<bool> UpdateParkingSlotAsync(ParkingSlot slot)
        {
            try
            {
                _logger.LogInformation("Updating parking slot with ID: {SlotId}", slot.Id);

                var existingSlot = await _unitOfWork.ParkingSlotRepository.GetByIdAsync(slot.Id);
                if (existingSlot == null)
                {
                    _logger.LogWarning("Parking slot not found with ID: {SlotId}", slot.Id);
                    return false;
                }

                existingSlot.SlotNumber = slot.SlotNumber;
                existingSlot.IsOccupied = slot.IsOccupied;
                existingSlot.LastUpdatedAt = DateTime.UtcNow;

                await _unitOfWork.ParkingSlotRepository.UpdateAsync(existingSlot);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("Parking slot updated successfully with ID: {SlotId}", slot.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating parking slot with ID: {SlotId}", slot.Id);
                return false;
            }
        }

        public async Task<bool> DeleteParkingSlotAsync(Guid slotId)
        {
            try
            {
                _logger.LogInformation("Deleting parking slot with ID: {SlotId}", slotId);

                var slot = await _unitOfWork.ParkingSlotRepository.GetByIdAsync(slotId);
                if (slot == null)
                {
                    _logger.LogWarning("Parking slot not found with ID: {SlotId}", slotId);
                    return false;
                }

                await _unitOfWork.ParkingSlotRepository.DeleteAsync(slot);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("Parking slot deleted successfully with ID: {SlotId}", slotId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting parking slot with ID: {SlotId}", slotId);
                return false;
            }
        }

        public async Task<IEnumerable<ParkingSlot>> GetAllParkingSlotsAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all parking slots...");
                return await _unitOfWork.ParkingSlotRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all parking slots.");
                return Enumerable.Empty<ParkingSlot>();
            }
        }
        public async Task<int> GetParkingSlotCountAsync()
        {
            return await _unitOfWork.ParkingSlotRepository.GetCountAsync();
        }
        public async Task<int> GetUsedSlotsCountAsync()
        {
            return await _unitOfWork.ParkingSlotRepository.GetUsedSlotsCountAsync();
        }

        public async Task<int> GetUnusedSlotsCountAsync()
        {
            return await _unitOfWork.ParkingSlotRepository.GetUnusedSlotsCountAsync();
        }

        public async Task<List<ParkingSlot>> GetAvailableSlotsAsync()
        {
            try
            {
                _logger.LogInformation("Fetching available parking slots...");
                var slots = await _unitOfWork.ParkingSlotRepository.GetAllAsync();
                return slots.Where(s => !s.IsOccupied).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching available parking slots.");
                return new List<ParkingSlot>();
            }
        }

        public async Task<ParkingSlot> GetParkingSlotByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Fetching parking slot by ID: {SlotId}", id);
                return await _unitOfWork.ParkingSlotRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching parking slot by ID: {SlotId}", id);
                return null!;
            }
        }

        public async Task<IEnumerable<ParkingSlot>> SearchParkingSlotsAsync(string search)
        {
            try
            {
                _logger.LogInformation("Searching parking slots with keyword: {Search}", search);
                var slots = await _unitOfWork.ParkingSlotRepository.GetAllAsync();
                return slots.Where(s => s.SlotNumber.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while searching for parking slots with keyword: {Search}", search);
                return Enumerable.Empty<ParkingSlot>();
            }
        }

        public async Task<bool> AssignRFIDAsync(Guid parkingSlotId, Guid VID)
        {
            try
            {
                _logger.LogInformation("Assigning RFID to parking slot ID: {SlotId}, Vehicle ID: {VID}", parkingSlotId, VID);

                var slot = await _unitOfWork.ParkingSlotRepository.GetByIdAsync(parkingSlotId);
                if (slot == null)
                {
                    _logger.LogWarning("Parking slot not found with ID: {SlotId}", parkingSlotId);
                    return false;
                }

                slot.VehicleID = VID;
                slot.LastUpdatedAt = DateTime.UtcNow;

                await _unitOfWork.ParkingSlotRepository.UpdateAsync(slot);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("RFID assigned successfully to parking slot ID: {SlotId}", parkingSlotId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while assigning RFID to parking slot ID: {SlotId}", parkingSlotId);
                return false;
            }
        }

        public async Task<ParkingSlot> GetParkingSlotByRFID(Guid VID)
        {
            try
            {
                _logger.LogInformation("Fetching parking slot by RFID (Vehicle ID): {VID}", VID);
                var slots = await _unitOfWork.ParkingSlotRepository.GetAllAsync();
                return slots.FirstOrDefault(s => s.VehicleID == VID)!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching parking slot by RFID (Vehicle ID): {VID}", VID);
                return null!;
            }
        }
    }
}