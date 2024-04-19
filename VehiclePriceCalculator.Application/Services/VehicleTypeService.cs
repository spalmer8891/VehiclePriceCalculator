using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.CQRS.Queries;
using VehiclePriceCalculator.Application.Interfaces;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;

namespace VehiclePriceCalculator.Application.Services
{
    public class VehicleTypeService:IVehicleTypeService
    {

        private readonly IMediator _mediator;

        public VehicleTypeService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<VehicleTypeModel>> GetVehicleTypeNameList()
        {
            return await _mediator.Send(new GetAllVehicleTypesQuery { });
        }
    }
}
