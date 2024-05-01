using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;

namespace VehiclePriceCalculator.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        T AddAsync(T entity);
        //Task UpdateAsync(T entity);
        //Task DeleteAsync(T entity);
    }
}
