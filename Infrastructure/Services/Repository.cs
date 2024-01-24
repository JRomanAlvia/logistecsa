using Microsoft.EntityFrameworkCore;
using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;

namespace Logistecsa.Infrastructure.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LogistecsaDbContext _context;
        private readonly ILogger<Repository<TEntity>> _logger;

        public Repository(LogistecsaDbContext context, ILogger<Repository<TEntity>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public TEntity Get(int id)
        {
            try
            {
                _logger.LogInformation($"Getting entity with ID {id}");
                return _context.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting entity with ID {id}: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                _logger.LogInformation($"Getting data list");
                return _context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting data list: {ex.Message}");
                throw;
            }
        }

        public void Add(TEntity entity)
        {
            try
            {
                _logger.LogInformation($"Adding entry to entity");
                _context.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while adding entry to entity: {ex.Message}");
                throw;
            }
        }
        public void Update(TEntity dbEntity, TEntity entity)
        {
            try
            {
                _logger.LogInformation($"Updating entry");
                _context.Set<TEntity>().Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while Updating entry: {ex.Message}");
                throw;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _logger.LogInformation($"Deleting entry");
                _context.Set<TEntity>().Remove(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while deleting entry: {ex.Message}");
                throw;
            }
        }

    }

}
