using TTATAutomation.Models;

namespace TTATAutomation.Repositories.Interfaces
{
  public interface IGateTransactionRepository : IRepository<GateTransaction>
  {
    Task<GateTransaction?> GetByVidAsync(Guid Vid);
    Task<bool> RegisterEntryAsync(GateTransaction transaction);
    Task<bool> RegisterExitAsync(Guid vehicleId);
  }
}