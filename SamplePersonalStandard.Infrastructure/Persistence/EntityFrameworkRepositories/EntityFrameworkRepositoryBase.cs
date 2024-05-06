using Microsoft.EntityFrameworkCore;
using SamplePersonalStandard.Core.BuildingBlocks;
using SamplePersonalStandard.Core.Repositories;
using System.Linq.Expressions;

namespace SamplePersonalStandard.Infrastructure.Persistence.EntityFrameworkRepositories
{
    public abstract class EntityFrameworkRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public EntityFrameworkRepositoryBase(AppDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task DeleteOneByIdAsync(Guid id)
        {
            var orderToDelete = await _dbSet.FirstOrDefaultAsync(r => r.Id == id);

            if (orderToDelete != null)
            {
                _dbSet.Remove(orderToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> whereCondition = null, Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            if (orderBy != null)
            {
                query = orderBy.Compile()(query);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task InsertOneAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateOneAsync(TEntity entity)
        {
            await Task.FromResult(_dbContext.Entry(entity).State = EntityState.Modified);
            await _dbContext.SaveChangesAsync();
        }
    }
}
