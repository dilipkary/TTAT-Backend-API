using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;
using TTATAutomation.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;
using TTATAutomation.Repositories.Implementations;

namespace TTATAutomation.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _unitOfWork.VehicleRepository.GetAllAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(Guid id)
        {
            return await _unitOfWork.VehicleRepository.GetByIdAsync(id);
        }
        public async Task<int> GetVehicleCountAsync()
        {
            return await _unitOfWork.VehicleRepository.GetCountAsync();
        }
        public async Task<IEnumerable<Vehicle>> SearchVehiclesAsync(string search)
        {
            var vehicles = await _unitOfWork.VehicleRepository.GetAllAsync();
            return vehicles.Where(v =>
                v.VehicleNumber.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                v.DriverName.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        public async Task RegisterVehicleAsync(Vehicle vehicle)
        {
            vehicle.Id = Guid.NewGuid();
            vehicle.CreatedAt = DateTime.UtcNow;
            vehicle.LastUpdatedAt = DateTime.UtcNow;
            await _unitOfWork.VehicleRepository.AddAsync(vehicle);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> AssignRFIDAsync(Guid vehicleId, string rfid)
        {
            var vehicle = await _unitOfWork.VehicleRepository.GetByIdAsync(vehicleId);
            if (vehicle == null) return false;

            vehicle.RFIDTag = EncryptRFID(rfid);
            vehicle.LastUpdatedAt = DateTime.UtcNow;

            await _unitOfWork.VehicleRepository.UpdateAsync(vehicle);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> UpdateVehicleAsync(Vehicle vehicle)
        {
            var existingVehicle = await _unitOfWork.VehicleRepository.GetByIdAsync(vehicle.Id);
            if (existingVehicle == null) return false;

            existingVehicle.VehicleNumber = vehicle.VehicleNumber;
            existingVehicle.DriverName = vehicle.DriverName;
            existingVehicle.DLNo = vehicle.DLNo;
            existingVehicle.Permit = vehicle.Permit;
            existingVehicle.Type = vehicle.Type;
            existingVehicle.LastUpdatedAt = DateTime.UtcNow;

            await _unitOfWork.VehicleRepository.UpdateAsync(existingVehicle);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleAsync(Guid id)
        {
            var vehicle = await _unitOfWork.VehicleRepository.GetByIdAsync(id);
            if (vehicle == null) return false;

            await _unitOfWork.VehicleRepository.DeleteAsync(vehicle);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        private string EncryptRFID(string rfid)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(rfid);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public async Task<Vehicle?> GetVehicleByRFID(string rfidTag)
        {
            return await _unitOfWork.VehicleRepository.GetByRFIDAsync(rfidTag);
        }

    }
}