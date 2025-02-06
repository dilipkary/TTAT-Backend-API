using TTATAutomation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTATAutomation.Services.Interfaces
{
    public interface IGateService
    {
        Task<bool> RegisterGateEntryAsync(GateTransaction transaction);
        Task<bool> RegisterGateExitAsync(Guid id);
        Task<IEnumerable<GateTransaction>> GetAllGateTransactionsAsync();
        Task<GateTransaction?> GetGateTransactionByIdAsync(Guid id);
        Task<bool> UpdateGateTransactionAsync(GateTransaction transaction);
        Task<bool> DeleteGateTransactionAsync(Guid id);
    }
}