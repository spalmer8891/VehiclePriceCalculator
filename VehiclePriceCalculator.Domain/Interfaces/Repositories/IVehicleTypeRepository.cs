using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;

namespace VehiclePriceCalculator.Domain.Interfaces.Repositories
{
    public interface IVehicleTypeRepository //: IGenericRepository<VehicleType>
    {
        Task<IEnumerable<VehicleType>> GetVehicleTypeListAsync();
    }
}
