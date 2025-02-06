using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTATAutomation.Data.Dto;
using TTATAutomation.Helpers;
using TTATAutomation.Models;
using TTATAutomation.Services.Interfaces;

namespace TTATAutomation.Controllers
{
    [Route("api/weighment")]
    [ApiController]
    [Authorize]
    public class WeighmentController : ControllerBase
    {
        private readonly IWeighmentService _weighmentService;
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<WeighmentController> _logger;

        public WeighmentController(IWeighmentService weighmentService, IVehicleService vehicleService, ILogger<WeighmentController> logger)
        {
            _weighmentService = weighmentService;
            _vehicleService = vehicleService;
            _logger = logger;
        }

        // Get all weighments
        [HttpGet]
        public async Task<IActionResult> GetAllWeighments()
        {
            try
            {
                _logger.LogInformation("Fetching all weighment records...");
                var weighments = await _weighmentService.GetAllWeighmentsAsync();
                return Ok(weighments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching weighments.");
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // Get weighment by RFID
        [HttpGet("{rfid}")]
        public async Task<IActionResult> GetWeighmentByRFID(string rfid)
        {
            try
            {
                _logger.LogInformation("Fetching weighment record for RFID: {RFID}", rfid);

                var vehicle = await _vehicleService.GetVehicleByRFID(rfid);
                if (vehicle == null)
                {
                    _logger.LogWarning("Vehicle not found for RFID: {RFID}", rfid);
                    return NotFound(new { message = "Vehicle not found" });
                }

                var weighment = await _weighmentService.GetWeighmentByVIDAsync(vehicle.Id);
                if (weighment == null)
                {
                    _logger.LogWarning("Weighment record not found for Vehicle ID: {VehicleId}", vehicle.Id);
                    return NotFound(new { message = "Weighment record not found" });
                }

                return Ok(weighment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching weighment for RFID: {RFID}", rfid);
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // Record first weighment
        [HttpPost("add")]
        public async Task<IActionResult> AddWeighment([FromBody] Weighment w)
        {
            await _weighmentService.AddWeighment(w);
            return Ok(new { message = "Vehicle Registered Successfully" });
        }

        [HttpPut("update/{Id}")]
        public async Task<IActionResult> AddWeighment(Guid Id, [FromBody] Weighment W)
        {
            W.Id = Id;
            var result = await _weighmentService.UpdateWeighmentAsync(W);
            if (!result) return NotFound(new { message = "Weighment update error" });

            return Ok(new { message = "Weigment Updated Successfully" });
        }

        // Record first weighment
        [HttpPost("first-weighment/{rfid}")]
        public async Task<IActionResult> RecordFirstWeighment(string rfid, [FromBody] decimal Weight)
        {
            try
            {
                _logger.LogInformation("Recording first weighment for RFID: {RFID}", rfid);

                var vehicle = await _vehicleService.GetVehicleByRFID(rfid);
                if (vehicle == null)
                {
                    _logger.LogWarning("Vehicle not found for RFID: {RFID}", rfid);
                    return BadRequest(new { message = "Vehicle not found" });
                }

                var wt = new Weighment
                {
                    VehicleId = vehicle.Id,
                    TareWeight = Weight,
                    Status = WeighmentStatus.FirstWeighmentRecorded,
                    EntryTimestamp = DateTime.UtcNow,
                };

                var result = await _weighmentService.RecordFirstWeighmentAsync(wt);
                if (!result)
                {
                    _logger.LogWarning("First weighment failed for RFID: {RFID}", rfid);
                    return BadRequest(new { message = "First weighment failed or already exists" });
                }

                _logger.LogInformation("First weighment recorded successfully for RFID: {RFID}", rfid);
                return Ok(new { message = "First Weighment Recorded Successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording first weighment for RFID: {RFID}", rfid);
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // Record second weighment
        [HttpPost("second-weighment/{rfid}")]
        public async Task<IActionResult> RecordSecondWeighment(string rfid, [FromBody] decimal exitWeight)
        {
            try
            {
                _logger.LogInformation("Recording second weighment for RFID: {RFID}", rfid);

                var vehicle = await _vehicleService.GetVehicleByRFID(rfid);
                if (vehicle == null)
                {
                    _logger.LogWarning("Vehicle not found for RFID: {RFID}", rfid);
                    return BadRequest(new { message = "Vehicle not found" });
                }
                var weighment = await _weighmentService.GetWeighmentActiveByVidAsync(vehicle.Id);


                weighment.VehicleId = vehicle.Id;
                weighment.GrossWeight = exitWeight;
                weighment.Status = WeighmentStatus.SecondWeighmentRecorded;
                //weighment.IsActive = false;
                weighment.ExitTimestamp = DateTime.UtcNow;


                var result = await _weighmentService.UpdateWeighmentAsync(weighment);
                if (!result)
                {
                    _logger.LogWarning("Second weighment failed for RFID: {RFID}", rfid);
                    return BadRequest(new { message = "Second weighment failed" });
                }

                _logger.LogInformation("Second weighment recorded successfully for RFID: {RFID}", rfid);
                return Ok(new { message = "Second Weighment Recorded Successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording second weighment for RFID: {RFID}", rfid);
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        // Delete weighment record
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeighment(Guid Id)
        {
            try
            {
                _logger.LogInformation("Deleting weighment record with ID: {WeighmentId}", Id);

                var result = await _weighmentService.DeleteWeighmentAsync(Id);
                if (!result)
                {
                    _logger.LogWarning("Weighment record not found with ID: {WeighmentId}", Id);
                    return NotFound(new { message = "Weighment record not found" });
                }

                _logger.LogInformation("Weighment record deleted successfully with ID: {WeighmentId}", Id);
                return Ok(new { message = "Weighment Record Deleted Successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting weighment record with ID: {WeighmentId}", Id);
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
        [HttpPost("approve-weighment/{rfid}")]
        public async Task<IActionResult> ApproveWeighment(string rfid)
        {
            try
            {
                _logger.LogInformation("Approving weighment for RFID: {RFID}", rfid);

                var vehicle = await _vehicleService.GetVehicleByRFID(rfid);
                if (vehicle == null)
                {
                    _logger.LogWarning("Vehicle not found for RFID: {RFID}", rfid);
                    return NotFound(new { message = "Vehicle not found" });
                }

                var weighment = await _weighmentService.GetWeighmentActiveByVidAsync(vehicle.Id);
                if (weighment == null || !weighment.GrossWeight.HasValue)
                {
                    _logger.LogWarning("Weighment record not found or incomplete for Vehicle ID: {VehicleId}", vehicle.Id);
                    return BadRequest(new { message = "Weighment record not found or incomplete" });
                }

                var result = await _weighmentService.ApproveWeighmentAsync(weighment);

                _logger.LogInformation("Weighment approval result for RFID: {RFID} - {Result}", rfid, result);

                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving weighment for RFID: {RFID}", rfid);
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
    }
}