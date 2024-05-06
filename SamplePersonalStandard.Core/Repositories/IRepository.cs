using System.Linq.Expressions;

namespace SamplePersonalStandard.Core.Repositories
{
    /// <summary>
    /// Define required CRUD operations
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> whereCondition = null, 
            Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> orderBy = null);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task InsertOneAsync(TEntity entity);
        Task UpdateOneAsync(TEntity entity);
        Task DeleteOneByIdAsync(Guid id);
    }
}
