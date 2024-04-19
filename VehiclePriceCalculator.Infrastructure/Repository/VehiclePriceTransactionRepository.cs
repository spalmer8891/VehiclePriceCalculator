using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Infrastructure.Data;
using VehiclePriceCalculator.Infrastructure.Interfaces;
using VehiclePriceCalculator.Infrastructure.UnitOfWork;


namespace VehiclePriceCalculator.Infrastructure.Repository
{
    public class VehiclePriceTransactionRepository : GenericRepository<VehiclePriceTransaction>, IVehiclePriceTransactionRepository
    {

        private readonly IUnitOfWork _unitOfWork;
        public VehiclePriceTransactionRepository(VehiclePriceCalculatorDbContext dbContext,IUnitOfWork unitOfWork) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehiclePriceTransaction>> GetVehiclePriceTransactionListAsync()
        {
            //var data = await GetAllAsync();
            var data = await _unitOfWork.VehiclePriceTransactionRepository.GetAllAsync();
            return data;
        }

        public async Task<VehiclePriceTransaction> AddVehiclePriceTransactionListAsync(VehiclePriceTransaction vehiclePriceTransaction)
        {
            var response = await _unitOfWork.VehiclePriceTransactionRepository.AddAsync(vehiclePriceTransaction);
            _unitOfWork.Save();

            return response;
            
        }




    }
}
