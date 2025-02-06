using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTATAutomation.Models;
using TTATAutomation.Services;
using TTATAutomation.Services.Interfaces;

namespace TTATAutomation.Controllers
{
    [Route("api/parking")]
    [ApiController]
    [Authorize]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;
        private readonly IParkingSlotService _parkingSlotService;

        public ParkingController(IParkingService parkingService, IParkingSlotService parkingSlotService)
        {
            _parkingService = parkingService;
            _parkingSlotService = parkingSlotService;
        }

        // 🚗 **Vehicle Entry**
        [HttpPost("log")]
        public async Task<IActionResult> RecordLog([FromBody] ParkingLog log)
        {
            var result = await _parkingService.AddParkingLogAsync(log);
            if (!result) return NotFound(new { message = "Failed to add Parking log" });

            return Ok(new { message = "Parking Log Entry Recorded Successfully" });
        }
        // 🚗 **Vehicle Entry**
        [HttpPut("log/{Id}")]
        public async Task<IActionResult> UpdateLog(Guid Id, [FromBody] ParkingLog log)
        {
            log.Id = Id;
            var result = await _parkingService.UpdateParkingLogAsync(log);
            if (!result) return NotFound(new { message = "Failed to Update Parking log" });

            return Ok(new { message = "Parking Log Entry Updated Successfully" });
        }
        // 🚗 **Vehicle Entry**
        [HttpPost("entry/{rfid}")]
        public async Task<IActionResult> VehicleEntry(string rfid)
        {
            var result = await _parkingService.RegisterParkingEntryAsync(rfid);
            if (!result) return NotFound(new { message = "RFID not found or already inside" });

            return Ok(new { message = "Vehicle Entry Recorded Successfully" });
        }

        // 🚗 **Vehicle Exit**
        [HttpPost("exit/{rfid}")]
        public async Task<IActionResult> VehicleExit(string rfid)
        {
            var result = await _parkingService.RegisterParkingExitAsync(rfid);
            if (!result) return NotFound(new { message = "RFID not found or not inside parking" });

            return Ok(new { message = "Vehicle Exit Recorded Successfully" });
        }

        // Parking Slot CRUD operations

        // Get all parking slots
        [HttpGet("slots")]
        public async Task<IActionResult> GetAllParkingSlots()
        {
            var slots = await _parkingSlotService.GetAllParkingSlotsAsync();
            return Ok(slots);
        }

        // Get a specific parking slot by ID
        [HttpGet("slots/{id}")]
        public async Task<IActionResult> GetParkingSlotById(Guid id)
        {
            var slot = await _parkingSlotService.GetParkingSlotByIdAsync(id);
            if (slot == null) return NotFound(new { message = "Parking Slot not found" });

            return Ok(slot);
        }

        // Add a new parking slot
        [HttpPost("slots")]
        public async Task<IActionResult> AddParkingSlot([FromBody] ParkingSlot slot)
        {
            if (slot == null) return BadRequest(new { message = "Invalid Parking Slot data" });

            var result = await _parkingSlotService.AddParkingSlotAsync(slot);
            if (!result) return BadRequest(new { message = "Error while adding parking slot" });

            return Ok("Parking Slot added Successfully");
        }

        // Update an existing parking slot
        [HttpPut("slots/{id}")]
        public async Task<IActionResult> UpdateParkingSlot(Guid id, [FromBody] ParkingSlot slot)
        {
            if (id != slot.Id) return BadRequest(new { message = "Slot ID mismatch" });

            var result = await _parkingSlotService.UpdateParkingSlotAsync(slot);
            if (!result) return NotFound(new { message = "Parking Slot not found" });

            return Ok(new { message = "Parking Slot Updated Successfully" });
        }

        // Delete a parking slot
        [HttpDelete("slots/{id}")]
        public async Task<IActionResult> DeleteParkingSlot(Guid id)
        {
            var result = await _parkingSlotService.DeleteParkingSlotAsync(id);
            if (!result) return NotFound(new { message = "Parking Slot not found" });

            return Ok(new { message = "Parking Slot Deleted Successfully" });
        }

        // Parking Log CRUD operations

        // Get all parking logs
        [HttpGet("logs")]
        public async Task<IActionResult> GetAllParkingLogs()
        {
            var parkingLogs = await _parkingService.GetAllParkingLogsAsync();
            //List<ParkingLog> l = logs.ToList<ParkingLog>();
            Console.WriteLine("count of records" + parkingLogs.Count<ParkingLog>());
            return Ok(parkingLogs);
        }
        // Get all parking logs
        [HttpGet("LogCount")]
        public async Task<IActionResult> GetParkingLogCount()
        {
            var count1 = await _parkingService.GetParkingCountAsync();
            return Ok(new { count = count1 });
        }

        [HttpGet("slots/SlotCount")]
        public async Task<IActionResult> GetParkingSlotCount()
        {
            var count1 = await _parkingService.GetParkingCountAsync();
            return Ok(new { count = count1 });
        }

        // Get a specific parking log by RFID
        [HttpGet("logs/{vid}")]
        public async Task<IActionResult> GetParkingLogByVid(Guid vid)
        {
            var log = await _parkingService.GetParkingLogByIdAsync(vid);
            if (log == null) return NotFound(new { message = "Parking Log not found" });

            return Ok(log);
        }

        // Delete a parking log
        [HttpDelete("logs/{id}")]
        public async Task<IActionResult> DeleteParkingLog(Guid id)
        {
            var result = await _parkingService.DeleteParkingLogAsync(id);
            if (!result) return NotFound(new { message = "Parking Log not found" });
            return Ok(new { message = "Parking Log Deleted Successfully" });
        }
        // ✅ Get count of used (occupied) slots
        [HttpGet("slots/used-slots")]
        public async Task<IActionResult> GetUsedSlotsCount()
        {
            var count = await _parkingSlotService.GetUsedSlotsCountAsync();
            return Ok(new { count = count });
        }

        // ✅ Get count of unused (available) slots
        [HttpGet("slots/unused-slots")]
        public async Task<IActionResult> GetUnusedSlotsCount()
        {
            var count = await _parkingSlotService.GetUnusedSlotsCountAsync();
            return Ok(new { count = count });
        }

    }
}