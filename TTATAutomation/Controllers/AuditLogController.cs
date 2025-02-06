using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TTATAutomation.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace TTATAutomation.Controllers
{
    [Route("api/auditlogs")]
    [ApiController]
    [Authorize]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        // ✅ Get all logs
        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _auditLogService.GetAllLogsAsync();
            return Ok(logs);
        }

        // ✅ Get log by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogById(Guid id)
        {
            var log = await _auditLogService.GetLogByIdAsync(id);
            if (log == null) return NotFound(new { message = "Log not found" });

            return Ok(log);
        }
    }
}