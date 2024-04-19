using AutoMapper;
using AutoMapper.Internal.Mappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.CQRS.Commands;
using VehiclePriceCalculator.Application.CQRS.Queries;
using VehiclePriceCalculator.Application.Interfaces;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Enum;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Domain.Model;

namespace VehiclePriceCalculator.Application.Services
{
    public class VehiclePriceTransactionService : IVehiclePriceTransactionService
    {

        private readonly IVehiclePriceTransactionRepository _vehiclePriceTransactionRepository;
        private readonly IVehiclePriceCalculate _calculateVehiclePrice;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public VehiclePriceTransactionService(IVehiclePriceTransactionRepository vehicleCostTransactionRepository, IVehiclePriceCalculate calculateVehiclePrice, IMapper mapper, IMediator mediator)
        {
            _vehiclePriceTransactionRepository = vehicleCostTransactionRepository ?? throw new ArgumentNullException(nameof(vehicleCostTransactionRepository));
            _calculateVehiclePrice = calculateVehiclePrice ?? throw new ArgumentNullException(nameof(calculateVehiclePrice));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<VehiclePriceTransactionModel>> GetVehiclePriceTransactionList()
        {
            var vehiclePriceTransactionList = await _vehiclePriceTransactionRepository.GetVehiclePriceTransactionListAsync();
            var mapped = _mapper.Map<IEnumerable<VehiclePriceTransactionModel>>(vehiclePriceTransactionList);
            return mapped;
        }

        public async Task<VehiclePriceTransactionModel> AddVehiclePriceTransactionList(VehiclePriceTransaction vehiclePriceTransaction)
        {
            var vehiclePriceTransactionObj = new AddVehiclePriceTransactionCommand
            {
                VehicleTypeId = vehiclePriceTransaction.VehicleTypeId ?? 0,
                VehiclePrice = vehiclePriceTransaction.VehiclePrice ?? 0,
                BasicFee = vehiclePriceTransaction.BasicFee ?? 0,
                SpecialFee = vehiclePriceTransaction.SpecialFee ?? 0,
                AssociationFee = vehiclePriceTransaction.AssociationFee ?? 0,
                StorageFee = vehiclePriceTransaction.StorageFee ?? 0,
                TotalCost = vehiclePriceTransaction.TotalCost ?? 0
            };
 
            var response = await _mediator.Send(vehiclePriceTransactionObj);
            var mediatrResponse = _mapper.Map<VehiclePriceTransactionModel>(response);
            return mediatrResponse;
        }

        public async Task<VehiclePriceTransactionModel> CalculateVehiclePrice(decimal basePrice, Domain.Enum.VehicleType vehicleType, decimal storageFee)
        {
            var vehicle = new Vehicle
            {
                BasePrice = basePrice,
                Type = vehicleType,
                StorageFee = storageFee
            };
            var vehiclePriceTransaction =  _calculateVehiclePrice.CalculateTotalCost(vehicle,vehicleType);
            var mapped = _mapper.Map<VehiclePriceTransactionModel>(vehiclePriceTransaction);
            return mapped;
        }
     
    }
}
