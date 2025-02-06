using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TTATAutomation.Models;
using TTATAutomation.Services.Interfaces;

namespace TTATAutomation.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    [Authorize]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterVehicle([FromBody] Vehicle vehicle)
        {
            await _vehicleService.RegisterVehicleAsync(vehicle);
            return Ok(new { message = "Vehicle Registered Successfully" });
        }

        [HttpPost("{id}/assign-rfid")]
        public async Task<IActionResult> AssignRFID(Guid id, [FromBody] string rfid)
        {
            var result = await _vehicleService.AssignRFIDAsync(id, rfid);
            if (!result) return NotFound(new { message = "Vehicle not found" });

            return Ok(new { message = "RFID Assigned Successfully" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(Guid id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound(new { message = "Vehicle not found" });

            return Ok(vehicle);
        }

        [HttpGet("getvehiclecount")]
        public async Task<IActionResult> GetVehicleCount()
        {
            var vehicle = await _vehicleService.GetVehicleCountAsync();
            if (vehicle == null) return NotFound(new { message = "Vehicle not found" });

            return Ok(new { count = vehicle });
        }
        [HttpGet("GetVehicles")]
        public async Task<IActionResult> GetVehicle()
        {
            var vehicle = await _vehicleService.GetAllVehiclesAsync();
            if (vehicle == null) return NotFound(new { message = "Vehicle not found" });

            return Ok(vehicle);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchVehicles([FromQuery] string search)
        {
            var vehicles = await _vehicleService.SearchVehiclesAsync(search);
            return Ok(vehicles);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(Guid id, [FromBody] Vehicle vehicle)
        {
            vehicle.Id = id;
            var result = await _vehicleService.UpdateVehicleAsync(vehicle);
            if (!result) return NotFound(new { message = "Vehicle not found" });

            return Ok(new { message = "Vehicle Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            var result = await _vehicleService.DeleteVehicleAsync(id);
            if (!result) return NotFound(new { message = "Vehicle not found" });

            return Ok(new { message = "Vehicle Deleted Successfully" });
        }
    }
}
