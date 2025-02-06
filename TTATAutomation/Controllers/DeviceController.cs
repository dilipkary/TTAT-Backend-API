using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTATAutomation.Models;
using TTATAutomation.Services.Interfaces;

namespace TTATAutomation.Controllers
{
    [Route("api/device")]
    [ApiController]
    [Authorize]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetAllDevices()
        {
            var devices = await _deviceService.GetAllDevicesAsync();
            return Ok(devices.ToList<Device>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDeviceById(Guid id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null) return NotFound();
            return Ok(device);
        }

        [HttpPost]
        public async Task<ActionResult> AddDevice([FromBody] Device device)
        {
            if (device == null) return BadRequest("Device data is required");

            await _deviceService.AddDeviceAsync(device);
            return CreatedAtAction(nameof(GetDeviceById), new { id = device.Id }, device);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDevice(Guid id, [FromBody] Device device)
        {

            device.Id = id;
            var updated = await _deviceService.UpdateDeviceAsync(device);
            if (!updated) return NotFound();

            return Ok("Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevice(Guid id)
        {
            var deleted = await _deviceService.DeleteDeviceAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}