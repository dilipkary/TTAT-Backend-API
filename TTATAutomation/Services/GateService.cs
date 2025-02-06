using Microsoft.EntityFrameworkCore;
using TTATAutomation.Data;
using TTATAutomation.Models;
using TTATAutomation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTATAutomation.Services.Implementations
{
    public class GateService : IGateService
    {
        private readonly AppDbContext _context;

        public GateService(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Register Vehicle Entry
        public async Task<bool> RegisterGateEntryAsync(GateTransaction transaction)
        {
            if (transaction == null)
                return false;

            transaction.Id = Guid.NewGuid();
            transaction.EntryTime = DateTime.UtcNow;
            transaction.Status = "IN";

            await _context.GateTransactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Register Vehicle Exit
        public async Task<bool> RegisterGateExitAsync(Guid id)
        {
            var transaction = await _context.GateTransactions.FindAsync(id);
            if (transaction == null || transaction.ExitTime.HasValue) return false;

            transaction.ExitTime = DateTime.UtcNow;
            transaction.Status = "OUT";

            _context.GateTransactions.Update(transaction);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Get All Gate Transactions
        public async Task<IEnumerable<GateTransaction>> GetAllGateTransactionsAsync()
        {
            return await _context.GateTransactions.ToListAsync();
        }

        // ✅ Get Specific Gate Transaction by ID
        public async Task<GateTransaction?> GetGateTransactionByIdAsync(Guid id)
        {
            return await _context.GateTransactions.FindAsync(id);
        }

        // ✅ Update Gate Transaction
        public async Task<bool> UpdateGateTransactionAsync(GateTransaction transaction)
        {
            var existingTransaction = await _context.GateTransactions.FindAsync(transaction.Id);
            if (existingTransaction == null) return false;

            existingTransaction.Status = transaction.Status;
            existingTransaction.EntryTime = transaction.EntryTime;
            existingTransaction.ExitTime = transaction.ExitTime;
            existingTransaction.VehicleId = transaction.VehicleId;

            _context.GateTransactions.Update(existingTransaction);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Delete Gate Transaction
        public async Task<bool> DeleteGateTransactionAsync(Guid id)
        {
            var transaction = await _context.GateTransactions.FindAsync(id);
            if (transaction == null) return false;

            _context.GateTransactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}