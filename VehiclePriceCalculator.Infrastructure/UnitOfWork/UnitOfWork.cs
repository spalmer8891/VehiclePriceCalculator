using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Infrastructure.Data;
using VehiclePriceCalculator.Infrastructure.Repository;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Domain.Interfaces;

namespace VehiclePriceCalculator.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly VehiclePriceCalculatorDbContext _context;
        private IVehicleTypeRepository _vehicleTypeRepository;
        private IVehiclePriceTransactionRepository _vehiclePriceTransactionRepository;
        //private IGenericRepository<VehicleType> _vehicleTypeRepository;
        //private IGenericRepository<VehiclePriceTransaction> _vehiclePriceTransactionRepository;
        private IAppLogger<VehicleType> _vehicleTypeLogger;
        private IAppLogger<VehiclePriceTransaction> _vehiclePriceTransactionLogger;

        public UnitOfWork(VehiclePriceCalculatorDbContext context,
                          IVehicleTypeRepository vehicleTypeRepository,
                          IVehiclePriceTransactionRepository vehiclePriceTransactionRepository,
                          IAppLogger<VehicleType> vehicleTypeLogger, 
                          IAppLogger<VehiclePriceTransaction> vehiclePriceTransactionLogger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _vehiclePriceTransactionRepository = vehiclePriceTransactionRepository ?? throw new ArgumentNullException(nameof(vehiclePriceTransactionRepository));
            _vehicleTypeLogger = vehicleTypeLogger ?? throw new ArgumentNullException(nameof(vehicleTypeLogger));
            _vehiclePriceTransactionLogger = vehiclePriceTransactionLogger ?? throw new ArgumentNullException(nameof(vehiclePriceTransactionLogger));
        }

        public IVehicleTypeRepository VehicleTypeRepository =>
               _vehicleTypeRepository ??= new VehicleTypeRepository(_context, _vehicleTypeLogger);

        public IVehiclePriceTransactionRepository VehiclePriceTransactionRepository =>
               _vehiclePriceTransactionRepository ??= new VehiclePriceTransactionRepository(_context, _vehiclePriceTransactionLogger);
        //public IGenericRepository<VehicleType> VehicleTypeRepository =>
        //_vehicleTypeRepository ??= new GenericRepository<VehicleType>(_context, _vehicleTypeLogger);

        //public IGenericRepository<VehiclePriceTransaction> VehiclePriceTransactionRepository =>
        //    _vehiclePriceTransactionRepository ??= new GenericRepository<VehiclePriceTransaction>(_context, _vehiclePriceTransactionLogger);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
