using TTATAutomation.Data;
using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;
using TTATAutomation.Services;
using TTATAutomation.Repositories.Implementations;
using TTATAutomation.Services.Interfaces;

namespace TTATAutomation.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IVehicleRepository VehicleRepository { get; }
        public IUserRepository UserRepository { get; }
        public IParkingRepository ParkingRepository { get; }
        public IParkingSlotRepository ParkingSlotRepository { get; }
        public IAdminRepository AdminRepository { get; }
        public IGateTransactionRepository GateRepository { get; }
        public IWeighmentRepository WeighmentRepository { get; }
        public IDeviceRepository DeviceRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            VehicleRepository = new VehicleRepository(context);
            UserRepository = new UserRepository(context);
            ParkingRepository = new ParkingRepository(context);
            ParkingSlotRepository = new ParkingSlotRepository(context);
            AdminRepository = new AdminRepository(context);
            GateRepository = new GateTransactionRepository(context);
            WeighmentRepository = new WeighmentRepository(context);
            DeviceRepository = new DeviceRepository(context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
