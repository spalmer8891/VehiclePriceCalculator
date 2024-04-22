using Microsoft.EntityFrameworkCore.Metadata.Internal;
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


namespace VehiclePriceCalculator.Infrastructure.Repository
{
    public class VehicleTypeRepository : GenericRepository<VehicleType>, IVehicleTypeRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<VehicleType> _logger;
        public VehicleTypeRepository(VehiclePriceCalculatorDbContext dbContext,IUnitOfWork unitOfWork, IAppLogger<VehicleType> logger) : base(dbContext,logger)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypeListAsync()
        {
            var data = await _unitOfWork.VehicleTypeRepository.GetAllAsync();
           
            return data;
        }


    }
}
