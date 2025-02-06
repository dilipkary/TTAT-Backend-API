using TTATAutomation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTATAutomation.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task LogInfoAsync(string message, string source);
        Task LogWarningAsync(string message, string source);
        Task LogErrorAsync(string message, string exception, string source);
        Task<IEnumerable<AuditLog>> GetAllLogsAsync();
        Task<AuditLog?> GetLogByIdAsync(Guid id);
    }
}