using AutoMapper;
using System.Collections.Generic;
using VehiclePriceCalculator.Application.Interfaces;
using VehiclePriceCalculator.WebApp.Interfaces;
using VehiclePriceCalculator.WebApp.ViewModels;
using VehiclePriceCalculator.Infrastructure.Constants;
using VehiclePriceCalculator.Domain.Entities;
using Microsoft.VisualBasic;

namespace VehiclePriceCalculator.WebApp.Services
{
    public class IndexPageService : IIndexPageService
    {
        private readonly IVehicleTypeService _vehicleTypeAppService;
        private readonly IVehiclePriceTransactionService _vehiclePriceTransactionAppService;
        private readonly IMapper _mapper;
        public IndexPageService(IVehicleTypeService vehicleTypeAppService,IVehiclePriceTransactionService vehiclePriceTransactionAppService, IMapper mapper)
        {
            _vehicleTypeAppService = vehicleTypeAppService ?? throw new ArgumentNullException(nameof(vehicleTypeAppService));
            _vehiclePriceTransactionAppService = vehiclePriceTransactionAppService ?? throw new ArgumentNullException(nameof(vehiclePriceTransactionAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetAllVehicleTypes()
        {
            var list = await _vehicleTypeAppService.GetVehicleTypeNameList();
            var mapped = _mapper.Map<IEnumerable<VehicleTypeViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<VehiclePriceTransactionViewModel>> GetAllVehiclePriceTransactions()
        {
            var list = await _vehiclePriceTransactionAppService.GetVehiclePriceTransactionList();
            var mapped = _mapper.Map<IEnumerable<VehiclePriceTransactionViewModel>>(list);
            return mapped;
        }

        public async Task<VehiclePriceTransactionViewModel> AddVehiclePriceTransactions(decimal basePrice, string vehicleType)
        {
            var response =  await _vehiclePriceTransactionAppService.CalculateVehiclePrice(basePrice, (Domain.Enum.VehicleType)Enum.Parse(typeof(Domain.Enum.VehicleType), vehicleType), VehiclePriceConstants.StorageFee);
            var mapped = _mapper.Map<VehiclePriceTransaction>(response);
            var data = await _vehiclePriceTransactionAppService.AddVehiclePriceTransactionList(mapped);
            var mappedViewModel = _mapper.Map<VehiclePriceTransactionViewModel>(data);
            return mappedViewModel;
        }

    }
}
