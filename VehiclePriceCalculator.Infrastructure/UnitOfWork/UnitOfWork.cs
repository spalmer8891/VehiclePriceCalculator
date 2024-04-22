using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Infrastructure.Data;
using VehiclePriceCalculator.Infrastructure.Interfaces;
using VehiclePriceCalculator.Infrastructure.Repository;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Domain.Interfaces;

namespace VehiclePriceCalculator.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly VehiclePriceCalculatorDbContext _context;
        private IAppLogger<VehicleType> _vehicleTypeLogger;
        private IAppLogger<VehiclePriceTransaction> _vehiclePriceTransactionLogger;

        public UnitOfWork(VehiclePriceCalculatorDbContext context, IAppLogger<VehicleType> vehicleTypeLogger, IAppLogger<VehiclePriceTransaction> vehiclePriceTransactionLogger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _vehicleTypeLogger = vehicleTypeLogger ?? throw new ArgumentNullException(nameof(vehicleTypeLogger));
            _vehiclePriceTransactionLogger = vehiclePriceTransactionLogger ?? throw new ArgumentNullException(nameof(vehiclePriceTransactionLogger));
        }

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
