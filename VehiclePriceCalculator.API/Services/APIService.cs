using AutoMapper;
using System.Collections.Generic;
using VehiclePriceCalculator.Application.Interfaces;
using VehiclePriceCalculator.API.Interfaces;
using VehiclePriceCalculator.API.Models;
using VehiclePriceCalculator.Infrastructure.Constants;
using VehiclePriceCalculator.Domain.Entities;
using Microsoft.VisualBasic;

namespace VehiclePriceCalculator.API.Services
{
    public class APIService : IAPIService
    {
        private readonly IVehicleTypeService _vehicleTypeApiService;
        private readonly IVehiclePriceTransactionService _vehiclePriceTransactionApiService;
        private readonly IMapper _mapper;
        public APIService(IVehicleTypeService vehicleTypeAppService,IVehiclePriceTransactionService vehiclePriceTransactionAppService, IMapper mapper)
        {
            _vehicleTypeApiService = vehicleTypeAppService ?? throw new ArgumentNullException(nameof(vehicleTypeAppService));
            _vehiclePriceTransactionApiService = vehiclePriceTransactionAppService ?? throw new ArgumentNullException(nameof(vehiclePriceTransactionAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetAllVehicleTypes()
        {
            var list = await _vehicleTypeApiService.GetVehicleTypeNameList();
            var mapped = _mapper.Map<IEnumerable<VehicleTypeViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<VehiclePriceTransactionViewModel>> GetAllVehiclePriceTransactions()
        {
            var list = await _vehiclePriceTransactionApiService.GetVehiclePriceTransactionList();
            var mapped = _mapper.Map<IEnumerable<VehiclePriceTransactionViewModel>>(list);
            return mapped;
        }

        public async Task<VehiclePriceTransactionViewModel> AddVehiclePriceTransactions(decimal basePrice, string vehicleType)
        {
            var response =  await _vehiclePriceTransactionApiService.CalculateVehiclePrice(basePrice, (Domain.Enum.VehicleType)Enum.Parse(typeof(Domain.Enum.VehicleType), vehicleType), VehiclePriceConstants.StorageFee);
            var mapped = _mapper.Map<VehiclePriceTransaction>(response);
            var data = await _vehiclePriceTransactionApiService.AddVehiclePriceTransactionList(mapped);
            var mappedViewModel = _mapper.Map<VehiclePriceTransactionViewModel>(data);
            return mappedViewModel;
        }

    }
}
