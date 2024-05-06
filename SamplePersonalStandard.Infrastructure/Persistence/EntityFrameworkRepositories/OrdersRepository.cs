using Microsoft.EntityFrameworkCore;
using SamplePersonalStandard.Core;
using SamplePersonalStandard.Core.Aggregates;
using SamplePersonalStandard.Core.BuildingBlocks;
using SamplePersonalStandard.Core.Repositories;
using System.Linq.Expressions;

namespace SamplePersonalStandard.Infrastructure.Persistence.EntityFrameworkRepositories
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class OrdersRepository : EntityFrameworkRepositoryBase<Order>, IOrderRepository
    {
        public OrdersRepository(AppDbContext context) : base(context)
        {
        }
        public override async Task<Order> GetAsync(Expression<Func<Order, bool>> whereCondition = null, Expression<Func<IQueryable<Order>, IOrderedQueryable<Order>>> orderBy = null)
        {
            IQueryable<Order> query = _dbSet;

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }
            if (orderBy != null)
            {
                query = orderBy.Compile()(query);
            }

            return await query
                .Include(o => o.Buyer)
                .Include(o => o.ShippingAddress)
                .Include(o => o.Items)
                .FirstOrDefaultAsync();
        }
    }
}
