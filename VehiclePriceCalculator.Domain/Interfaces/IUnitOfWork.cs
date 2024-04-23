using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;

namespace VehiclePriceCalculator.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IGenericRepository<VehicleType> VehicleTypeRepository { get; }
        //IGenericRepository<VehiclePriceTransaction> VehiclePriceTransactionRepository { get; }
        IVehicleTypeRepository VehicleTypeRepository { get; }
        IVehiclePriceTransactionRepository VehiclePriceTransactionRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
