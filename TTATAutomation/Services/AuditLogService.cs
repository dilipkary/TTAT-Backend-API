using Microsoft.EntityFrameworkCore;
using TTATAutomation.Data;
using TTATAutomation.Models;
using TTATAutomation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTATAutomation.Services.Implementations
{
    public class AuditLogService : IAuditLogService
    {
        private readonly AppDbContext _context;

        public AuditLogService(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Log an informational message
        public async Task LogInfoAsync(string message, string source)
        {
            await LogAsync("INFO", message, null, source);
        }

        // ✅ Log a warning message
        public async Task LogWarningAsync(string message, string source)
        {
            await LogAsync("WARNING", message, null, source);
        }

        // ✅ Log an error message with exception details
        public async Task LogErrorAsync(string message, string exception, string source)
        {
            await LogAsync("ERROR", message, exception, source);
        }

        // ✅ Helper method to log messages
        private async Task LogAsync(string logLevel, string message, string? exception, string source)
        {
            var log = new AuditLog
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                LogLevel = logLevel,
                Message = message,
                Exception = exception,
                Source = source
            };

            await _context.AuditLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        // ✅ Retrieve all logs
        public async Task<IEnumerable<AuditLog>> GetAllLogsAsync()
        {
            return await _context.AuditLogs.ToListAsync();
        }

        // ✅ Retrieve a specific log by ID
        public async Task<AuditLog?> GetLogByIdAsync(Guid id)
        {
            return await _context.AuditLogs.FindAsync(id);
        }
    }
}