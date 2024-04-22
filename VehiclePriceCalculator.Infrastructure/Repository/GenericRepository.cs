using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Infrastructure.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Infrastructure.UnitOfWork;

namespace VehiclePriceCalculator.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<T> _db;
        protected readonly IAppLogger<T> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(DbContext dbContext,IAppLogger<T> logger, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _db = _dbContext.Set<T>();
            var entities = dbContext.Set<T>().ToList();
            entities.ForEach(entity => dbContext.Entry(entity).Reload()); //reload to work with fresh db context data
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork=unitOfWork;
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

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                _unitOfWork.Save(); //save record to database
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
