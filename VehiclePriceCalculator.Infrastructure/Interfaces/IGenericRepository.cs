using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;

namespace VehiclePriceCalculator.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {

        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
