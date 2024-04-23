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


namespace VehiclePriceCalculator.Infrastructure.Repository
{
    public class VehicleTypeRepository : GenericRepository<VehicleType>, IVehicleTypeRepository
    {
 
        private readonly IAppLogger<VehicleType> _logger;
        public VehicleTypeRepository(VehiclePriceCalculatorDbContext dbContext, IAppLogger<VehicleType> logger) : base(dbContext,logger)
        {

        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypeListAsync()
        {
            var data = await GetAllAsync();
           
            return data;
        }


    }
}
