using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;

namespace VehiclePriceCalculator.Application.CQRS.Queries
{
    public class GetAllVehicleTypesQueryHandler : IRequestHandler<GetAllVehicleTypesQuery, IEnumerable<VehicleTypeModel>>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public GetAllVehicleTypesQueryHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository  ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<IEnumerable<VehicleTypeModel>> Handle(GetAllVehicleTypesQuery request, CancellationToken cancellationToken)
        {
            var vehicleTypesList = await _vehicleTypeRepository.GetVehicleTypeListAsync();
            var mapped = _mapper.Map<IEnumerable<VehicleTypeModel>>(vehicleTypesList);

            return mapped;
        }
    }


}
