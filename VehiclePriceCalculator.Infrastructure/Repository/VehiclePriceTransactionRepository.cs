using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Infrastructure.Data;
using VehiclePriceCalculator.Infrastructure.Interfaces;
using VehiclePriceCalculator.Infrastructure.UnitOfWork;


namespace VehiclePriceCalculator.Infrastructure.Repository
{
    public class VehiclePriceTransactionRepository : GenericRepository<VehiclePriceTransaction>, IVehiclePriceTransactionRepository
    {

        private readonly IAppLogger<VehiclePriceTransaction> _logger;
        private readonly IUnitOfWork unitOfWork;
        
        public VehiclePriceTransactionRepository(VehiclePriceCalculatorDbContext dbContext,IAppLogger<VehiclePriceTransaction> logger, IUnitOfWork unitOfWork) : base(dbContext,logger,unitOfWork)
        {
           
        }

        public async Task<IEnumerable<VehiclePriceTransaction>> GetVehiclePriceTransactionListAsync()
        {
            var data = await GetAllAsync();
            return data;
        }

        public async Task<VehiclePriceTransaction> AddVehiclePriceTransactionListAsync(VehiclePriceTransaction vehiclePriceTransaction)
        {
            VehiclePriceTransaction response = new VehiclePriceTransaction();
            try
            {
                response = await AddAsync(vehiclePriceTransaction);
               
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred in the {nameof(AddVehiclePriceTransactionListAsync)} method: {ex}");
            }

            return response;
            
        }




    }
}
