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

namespace VehiclePriceCalculator.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly VehiclePriceCalculatorDbContext _context;

        private IGenericRepository<VehicleType> _VehicleTypeRepository;
        private IGenericRepository<VehiclePriceTransaction> _VehiclePriceTransactionRepository;

        public UnitOfWork(VehiclePriceCalculatorDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IGenericRepository<VehicleType> VehicleTypeRepository => _VehicleTypeRepository ??= new GenericRepository<VehicleType>(_context);
        public IGenericRepository<VehiclePriceTransaction> VehiclePriceTransactionRepository => _VehiclePriceTransactionRepository ??= new GenericRepository<VehiclePriceTransaction>(_context);

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
