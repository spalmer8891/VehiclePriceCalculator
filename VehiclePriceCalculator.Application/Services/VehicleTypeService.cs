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
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;

namespace VehiclePriceCalculator.Application.Services
{
    public class VehicleTypeService:IVehicleTypeService
    {

        private readonly IMediator _mediator;
        private readonly IAppLogger<VehicleTypeService> _logger;

        public VehicleTypeService(IMediator mediator, IAppLogger<VehicleTypeService> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<VehicleTypeModel>> GetVehicleTypeNameList()
        {
            IEnumerable<VehicleTypeModel> data = Enumerable.Empty<VehicleTypeModel>();

            try
            {
                data = await _mediator.Send(new GetAllVehicleTypesQuery { }); //send mediatR request to get vehicle types
            }catch(Exception ex)
            {
                _logger.LogError($"An error occurred in the {nameof(GetVehicleTypeNameList)} method: {ex}");
            }

            return data;
        }
    }
}
