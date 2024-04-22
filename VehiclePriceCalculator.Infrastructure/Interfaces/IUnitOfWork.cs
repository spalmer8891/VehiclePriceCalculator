using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;

namespace VehiclePriceCalculator.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IGenericRepository<VehicleType> VehicleTypeRepository { get; }
        //IGenericRepository<VehiclePriceTransaction> VehiclePriceTransactionRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
