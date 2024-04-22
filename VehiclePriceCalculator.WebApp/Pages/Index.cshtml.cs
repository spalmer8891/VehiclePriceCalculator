using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using VehiclePriceCalculator.Shared.Interfaces;
using VehiclePriceCalculator.Shared.Models;
using VehiclePriceCalculator.Shared.Interfaces;

namespace VehiclePriceCalculator.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public decimal BasePrice { get; set; } //Bind Property to front end
        [BindProperty]
        public string VehicleType { get; set; } //Bind Property to front end
        public IOrderedEnumerable<KeyValuePair<int, string>> VehicleTypeList { get; set; }
        public IEnumerable<VehiclePriceTransactionViewModel> VehiclePriceTransactionList { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly IPresentationService _presentationService;
        //private readonly IIndexPageService _indexPageService;

        public IndexModel(IPresentationService _presentationService, ILogger<IndexModel> logger)
        {     //initialize properties and check for exceptions
            this._presentationService = _presentationService ?? throw new ArgumentNullException(nameof(_presentationService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        public async Task OnGet()
        {
            try
            {
                var vehicleTypeList = await _presentationService.GetAllVehicleTypes(); //Get all vehicles types
                var vehicleTypeSelectList = vehicleTypeList.ToDictionary(x => x.Id, x => x.VehicleTypeName).OrderBy(x => x.Value); //convert list to dictionary to be used in dropdownlist
                VehicleTypeList = vehicleTypeSelectList;

                var vehiclePriceTransactionList = await _presentationService.GetAllVehiclePriceTransactions(); //Get all vehicle price transactions

                VehiclePriceTransactionList = vehiclePriceTransactionList.Select(x =>
                {
                    //convert VehicleTypeId to respective enum text value
                    x.VehicleTypeName = x.VehicleTypeId == (int)(Domain.Enum.VehicleType)x.VehicleTypeId ? ((Domain.Enum.VehicleType)x.VehicleTypeId).ToString() : "";
                    return x;
                }).ToList();
            }catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the {MethodName} method", nameof(OnGet));
            }

        }

        public async Task OnPost()
        {
            try
            {
                var basePrice = BasePrice; //data from front end
                var vehicleType = VehicleType; //data from front end
                var vehiclePriceTransactionSingle = await _presentationService.AddVehiclePriceTransactions(basePrice, vehicleType); //call service to add vehicle price transaction

                var vehiclePriceTransactionList = await _presentationService.GetAllVehiclePriceTransactions();

                VehiclePriceTransactionList = vehiclePriceTransactionList.Select(x =>
                {
                    //convert VehicleTypeId to respective enum text value
                    x.VehicleTypeName = x.VehicleTypeId == (int)(Domain.Enum.VehicleType)x.VehicleTypeId ? ((Domain.Enum.VehicleType)x.VehicleTypeId).ToString() : "";
                    return x;
                }).ToList();

                var vehicleTypeList = await _presentationService.GetAllVehicleTypes();
                var vehicleTypeSelectList = vehicleTypeList.ToDictionary(x => x.Id, x => x.VehicleTypeName).OrderBy(x => x.Value);
                VehicleTypeList = vehicleTypeSelectList; //add vehicle types to select dropDownList
                BasePrice = 0; //clear base price field

            }catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the {MethodName} method", nameof(OnPost));
            }
        }
    }
}
