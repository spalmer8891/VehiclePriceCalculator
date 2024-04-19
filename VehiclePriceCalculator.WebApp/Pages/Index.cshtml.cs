using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using VehiclePriceCalculator.WebApp.Interfaces;
using VehiclePriceCalculator.WebApp.ViewModels;

namespace VehiclePriceCalculator.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public decimal BasePrice { get; set; }
        [BindProperty]
        public string VehicleType { get; set; }
        public IOrderedEnumerable<KeyValuePair<int, string>> VehicleTypeList { get; set; }
        public IEnumerable<VehiclePriceTransactionViewModel> VehiclePriceTransactionList { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly IIndexPageService _indexPageService;

        public IndexModel(IIndexPageService indexPageService, ILogger<IndexModel> logger)
        {
            _indexPageService = indexPageService ?? throw new ArgumentNullException(nameof(indexPageService));
            _logger = logger;
        }

        public async Task OnGet()
        {
          
            var vehicleTypeList = await _indexPageService.GetAllVehicleTypes();
            var vehicleTypeSelectList = vehicleTypeList.ToDictionary(x => x.Id, x => x.VehicleTypeName).OrderBy(x => x.Value);
            VehicleTypeList = vehicleTypeSelectList;

            var vehiclePriceTransactionList = await _indexPageService.GetAllVehiclePriceTransactions();
            
            VehiclePriceTransactionList = vehiclePriceTransactionList.Select(x =>
            {
                //convert VehicleTypeId to respective enum text value
                x.VehicleTypeName = x.VehicleTypeId == (int)(Domain.Enum.VehicleType)x.VehicleTypeId ? ((Domain.Enum.VehicleType)x.VehicleTypeId).ToString() : "";
                return x;
            }).ToList();

        }

        public async Task OnPost()
        {

            var basePrice = BasePrice;
            var vehicleType = VehicleType;
            var vehiclePriceTransactionSingle = await _indexPageService.AddVehiclePriceTransactions(basePrice,vehicleType);
            
            var vehiclePriceTransactionList = await _indexPageService.GetAllVehiclePriceTransactions();

            VehiclePriceTransactionList = vehiclePriceTransactionList.Select(x =>
            {
                //convert VehicleTypeId to respective enum text value
                x.VehicleTypeName = x.VehicleTypeId == (int)(Domain.Enum.VehicleType)x.VehicleTypeId ? ((Domain.Enum.VehicleType)x.VehicleTypeId).ToString() : "";
                return x;
            }).ToList();

            var vehicleTypeList = await _indexPageService.GetAllVehicleTypes();
            var vehicleTypeSelectList = vehicleTypeList.ToDictionary(x => x.Id, x => x.VehicleTypeName).OrderBy(x => x.Value);
            VehicleTypeList = vehicleTypeSelectList;
        }
    }
}
