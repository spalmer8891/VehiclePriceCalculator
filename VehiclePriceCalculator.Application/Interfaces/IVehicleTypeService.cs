using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.Models;

namespace VehiclePriceCalculator.Application.Interfaces
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleTypeModel>> GetVehicleTypeNameList();
    }
}
