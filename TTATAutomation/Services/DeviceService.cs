using TTATAutomation.Models;
using TTATAutomation.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTATAutomation.Repositories.Interfaces;
using TTATAutomation.Data; // Add this line

namespace TTATAutomation.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeviceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _unitOfWork.DeviceRepository.GetAllAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(Guid id)
        {
            return await _unitOfWork.DeviceRepository.GetByIdAsync(id);
        }

        public async Task AddDeviceAsync(Device device)
        {
            await _unitOfWork.DeviceRepository.AddAsync(device);
            await _unitOfWork.CompleteAsync();

        }

        public async Task<bool> UpdateDeviceAsync(Device device)
        {
            var d = await _unitOfWork.DeviceRepository.GetByIdAsync(device.Id);
            if (d == null) return false;
            d.DeviceName = device.DeviceName;
            d.IP = device.IP;
            d.Port = device.Port;
            d.Protocol = device.Protocol;
            await _unitOfWork.DeviceRepository.UpdateAsync(device);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteDeviceAsync(Guid id)
        {
            var d = await _unitOfWork.DeviceRepository.GetByIdAsync(id);
            if (d == null) return false;

            await _unitOfWork.DeviceRepository.DeleteAsync(d);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}