using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Domain.Interfaces;


namespace VehiclePriceCalculator.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<T> _db;
        protected readonly IAppLogger<T> _logger;

        public GenericRepository(DbContext dbContext,IAppLogger<T> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _db = _dbContext.Set<T>();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            List<T> data = new List<T>();

            try
            {
                data = await _db.ToListAsync(); //retrieve data and convert to list

            }catch (Exception ex)
            {
                _logger.LogError($"An error occurred in the {nameof(GetAllAsync)} method: {ex}");
            }

            return data;
        }

        public T AddAsync(T entity)
        {
            try
            {
                _db.Add(entity);
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred in the {nameof(AddAsync)} method: {ex}");
            }
           
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

    }

}
