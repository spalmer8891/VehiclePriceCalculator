using AutoMapper;
using System.Collections.Generic;
using VehiclePriceCalculator.Application.Interfaces;
using VehiclePriceCalculator.WebApp.Interfaces;
using VehiclePriceCalculator.WebApp.ViewModels;
using VehiclePriceCalculator.Infrastructure.Constants;
using VehiclePriceCalculator.Domain.Entities;
using Microsoft.VisualBasic;
using VehiclePriceCalculator.WebApp.Pages;
using VehiclePriceCalculator.Application.Models;

namespace VehiclePriceCalculator.WebApp.Services
{
    public class IndexPageService : IIndexPageService
    {
        private readonly IVehicleTypeService _vehicleTypeAppService;
        private readonly IVehiclePriceTransactionService _vehiclePriceTransactionAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<IndexPageService> _logger;
        public IndexPageService(IVehicleTypeService vehicleTypeAppService,IVehiclePriceTransactionService vehiclePriceTransactionAppService, IMapper mapper, ILogger<IndexPageService> logger)
        {
            _vehicleTypeAppService = vehicleTypeAppService ?? throw new ArgumentNullException(nameof(vehicleTypeAppService));
            _vehiclePriceTransactionAppService = vehiclePriceTransactionAppService ?? throw new ArgumentNullException(nameof(vehiclePriceTransactionAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetAllVehicleTypes()
        {
            IEnumerable<VehicleTypeModel> list = Enumerable.Empty<VehicleTypeModel>();
            IEnumerable<VehicleTypeViewModel> mapped = Enumerable.Empty<VehicleTypeViewModel>();

            try
            {
                list = await _vehicleTypeAppService.GetVehicleTypeNameList();
                mapped = _mapper.Map<IEnumerable<VehicleTypeViewModel>>(list);
               
            }catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the {MethodName} method", nameof(GetAllVehicleTypes));
            }

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
