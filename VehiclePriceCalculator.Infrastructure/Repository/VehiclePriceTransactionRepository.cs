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

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<VehiclePriceTransaction> _logger;
        
        public VehiclePriceTransactionRepository(VehiclePriceCalculatorDbContext dbContext,IUnitOfWork unitOfWork, IAppLogger<VehiclePriceTransaction> logger) : base(dbContext,logger)
        {
            _unitOfWork = unitOfWork;
           
        }

        public async Task<IEnumerable<VehiclePriceTransaction>> GetVehiclePriceTransactionListAsync()
        {
            var data = await _unitOfWork.VehiclePriceTransactionRepository.GetAllAsync();
            
            return data;
        }

        public async Task<VehiclePriceTransaction> AddVehiclePriceTransactionListAsync(VehiclePriceTransaction vehiclePriceTransaction)
        {
            VehiclePriceTransaction response = new VehiclePriceTransaction();
            try
            {
                response = await _unitOfWork.VehiclePriceTransactionRepository.AddAsync(vehiclePriceTransaction);
                _unitOfWork.Save(); //save record to database
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred in the {nameof(AddVehiclePriceTransactionListAsync)} method: {ex}");
            }

            return response;
            
        }




    }
}
