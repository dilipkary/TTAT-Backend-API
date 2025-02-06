using TTATAutomation.Models;

namespace TTATAutomation.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleRepository VehicleRepository { get; }
        IUserRepository UserRepository { get; }
        IParkingRepository ParkingRepository { get; }
        IAdminRepository AdminRepository { get; }
        IGateTransactionRepository GateRepository { get; }
        IParkingSlotRepository ParkingSlotRepository { get; }
        IWeighmentRepository WeighmentRepository { get; }
        IDeviceRepository DeviceRepository { get; }
        Task<int> CompleteAsync(); // Commit all changes to the database
    }
}
