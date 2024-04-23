using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;

namespace VehiclePriceCalculator.Application.CQRS.Queries
{
    public class GetAllVehicleTypesQueryHandler : IRequestHandler<GetAllVehicleTypesQuery, IEnumerable<VehicleTypeModel>>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetAllVehicleTypesQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllVehicleTypesQueryHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper, IAppLogger<GetAllVehicleTypesQueryHandler> logger, IUnitOfWork unitOfWork)
        {
            _vehicleTypeRepository = vehicleTypeRepository  ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        }

        public async Task<IEnumerable<VehicleTypeModel>> Handle(GetAllVehicleTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<VehicleType> vehicleTypesList = Enumerable.Empty<VehicleType>();
            IEnumerable<VehicleTypeModel> mapped = Enumerable.Empty<VehicleTypeModel>();

            try {
                vehicleTypesList = await _unitOfWork.VehicleTypeRepository.GetVehicleTypeListAsync();
                //vehicleTypesList = await _vehicleTypeRepository.GetVehicleTypeListAsync();
                mapped = _mapper.Map<IEnumerable<VehicleTypeModel>>(vehicleTypesList);
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred in the {nameof(GetAllVehicleTypesQueryHandler)} method: {ex}");
            }
            

            return mapped;
        }
    }


}
