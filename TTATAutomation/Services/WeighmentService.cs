using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;
using TTATAutomation.Services.Interfaces;
using TTATAutomation.Helpers;
using TTATAutomation.Data.Dto;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TTATAutomation.Services
{
    public class WeighmentService : IWeighmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WeighmentService> _logger;

        public WeighmentService(IUnitOfWork unitOfWork, ILogger<WeighmentService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<int> GetParkingSlotCountAsync()
        {
            return await _unitOfWork.ParkingSlotRepository.GetCountAsync();
        }
        public async Task<Weighment> GetWeighmentByWIdAsync(Guid WId)
        {
            try
            {
                return await _unitOfWork.WeighmentRepository.GetByIdAsync(WId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching weighment by ID: {WeighmentId}", WId);
                throw;
            }
        }

        public async Task<bool> AddWeighment(Weighment w)
        {

            try
            {
                await _unitOfWork.WeighmentRepository.AddAsync(w);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all weighments");
                throw;

            }
            return true;
        }
        public async Task<IEnumerable<Weighment>> GetAllWeighmentsAsync()
        {
            try
            {
                return await _unitOfWork.WeighmentRepository.GetAllWeighmentsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all weighments");
                throw;
            }
        }

        public async Task<bool> RecordFirstWeighmentAsync(Weighment wt)
        {
            try
            {
                await _unitOfWork.WeighmentRepository.AddAsync(wt);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording first weighment for vehicle: {VehicleNumber}", wt.VehicleId);
                return false;
            }
        }

        public async Task<bool> RecordSecondWeighmentAsync(Weighment wt)
        {
            try
            {


                await _unitOfWork.WeighmentRepository.UpdateAsync(wt);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording second weighment for vehicle ID: {VehicleId}", wt.VehicleId);
                return false;
            }
        }

        public async Task<string> ApproveWeighmentAsync(Weighment wt)
        {
            try
            {
                var weighment = wt;

                decimal netWeight = weighment.NetWeight ?? 0;
                decimal tolerance = (WeighmentSettings.TolerancePercentage / 100) * WeighmentSettings.MaxNetWeight;
                if (netWeight > WeighmentSettings.MaxNetWeight - tolerance && netWeight <= WeighmentSettings.MaxNetWeight)
                {
                    //weighment.Status = "Warning - Near Weight Limit";
                    await SendAlertAsync(weighment.VehicleId, "Weighment near upper limit.");
                }
                else
                {
                    weighment.Status = WeighmentStatus.Approved;
                    weighment.ExitTimestamp = DateTime.Now;
                    weighment.IsActive = false;
                }
                if (netWeight + tolerance < WeighmentSettings.MinNetWeight)
                {
                    //weighment.Status = "Rejected - Below Minimum Weight";
                    await SendAlertAsync(weighment.VehicleId, "Weighment below minimum limit.");
                    await _unitOfWork.CompleteAsync();
                    return "Rejected - Weight too low.";
                }

                if (netWeight - tolerance > WeighmentSettings.MaxNetWeight)
                {
                    //weighment.Status = "Rejected - Overloaded";
                    await SendAlertAsync(weighment.VehicleId, "Vehicle overloaded.");
                    await _unitOfWork.CompleteAsync();
                    return "Rejected - Overloaded.";
                }

                await _unitOfWork.CompleteAsync();
                return $"Weighment Approved: Net Weight = {netWeight} kg";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving weighment for vehicle ID: {VehicleId}", wt.VehicleId);
                return "Error processing approval.";
            }
        }

        public async Task<bool> DeleteWeighmentAsync(Guid WId)
        {
            var w = await _unitOfWork.WeighmentRepository.GetByIdAsync(WId);
            if (w == null) return false;
            try
            {
                await _unitOfWork.WeighmentRepository.DeleteAsync(w);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting weighment with ID: {WeighmentId}", WId);
                return false;
            }
        }

        public async Task<bool> UpdateWeighmentAsync(Weighment weighment)
        {
            try
            {
                await _unitOfWork.WeighmentRepository.UpdateAsync(weighment);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating weighment with ID: {WeighmentId}", weighment.Id);
                return false;
            }
        }

        public async Task<Weighment?> GetWeighmentActiveByVidAsync(Guid Vid)
        {
            try
            {
                return await _unitOfWork.WeighmentRepository.GetWeighmentActiveByVidAsync(Vid)!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching active weighment by vehicle ID: {VehicleId}", Vid);
                throw;
            }
        }

        public async Task<Weighment?> GetWeighmentByVIDAsync(Guid VID)
        {
            try
            {
                return await _unitOfWork.WeighmentRepository.GetWeighmentByVIDAsync(VID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching weighment by vehicle ID: {VehicleId}", VID);
                throw;
            }
        }

        private async Task<string> SendAlertAsync(Guid vehicleId, string message)
        {
            _logger.LogWarning("ALERT: Vehicle ID {VehicleId} - {Message}", vehicleId, message);
            return $"ALERT: Vehicle ID {vehicleId} - {message}";
            await Task.CompletedTask;
        }
    }
}
