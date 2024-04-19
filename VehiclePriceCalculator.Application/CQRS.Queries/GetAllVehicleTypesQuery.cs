using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;

namespace VehiclePriceCalculator.Application.CQRS.Queries
{
    public class GetAllVehicleTypesQuery : IRequest<IEnumerable<VehicleTypeModel>>
    {

    }
}
