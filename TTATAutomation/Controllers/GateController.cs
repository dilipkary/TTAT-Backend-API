using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TTATAutomation.Models;
using TTATAutomation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTATAutomation.Controllers
{
    [Route("api/gates")]
    [ApiController]
    [Authorize]
    public class GateController : ControllerBase
    {
        private readonly IGateService _gateService;

        public GateController(IGateService gateService)
        {
            _gateService = gateService;
        }

        // 📌 **Register Vehicle Entry at Gate**
        [HttpPost("entry")]
        public async Task<IActionResult> RegisterGateEntry([FromBody] GateTransaction transaction)
        {
            if (transaction == null) return BadRequest(new { message = "Invalid gate transaction data" });

            var result = await _gateService.RegisterGateEntryAsync(transaction);
            if (!result) return BadRequest(new { message = "Error recording gate entry" });

            return Ok(new { message = "Vehicle Entry Recorded Successfully" });
        }

        // 📌 **Register Vehicle Exit at Gate**
        [HttpPost("exit/{id}")]
        public async Task<IActionResult> RegisterGateExit(Guid id)
        {
            var result = await _gateService.RegisterGateExitAsync(id);
            if (!result) return NotFound(new { message = "Gate transaction not found or vehicle already exited" });

            return Ok(new { message = "Vehicle Exit Recorded Successfully" });
        }

        // 📌 **Get All Gate Transactions**
        [HttpGet]
        public async Task<IActionResult> GetAllGateTransactions()
        {
            var transactions = await _gateService.GetAllGateTransactionsAsync();
            return Ok(transactions);
        }

        // 📌 **Get a Specific Gate Transaction by ID**
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGateTransactionById(Guid id)
        {
            var transaction = await _gateService.GetGateTransactionByIdAsync(id);
            if (transaction == null) return NotFound(new { message = "Gate transaction not found" });

            return Ok(transaction);
        }

        // 📌 **Update a Gate Transaction**
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGateTransaction(Guid id, [FromBody] GateTransaction transaction)
        {
            if (id != transaction.Id) return BadRequest(new { message = "Transaction ID mismatch" });

            var result = await _gateService.UpdateGateTransactionAsync(transaction);
            if (!result) return NotFound(new { message = "Gate transaction not found" });

            return Ok(new { message = "Gate Transaction Updated Successfully" });
        }

        // 📌 **Delete a Gate Transaction**
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGateTransaction(Guid id)
        {
            var result = await _gateService.DeleteGateTransactionAsync(id);
            if (!result) return NotFound(new { message = "Gate transaction not found" });

            return Ok(new { message = "Gate Transaction Deleted Successfully" });
        }
    }
}