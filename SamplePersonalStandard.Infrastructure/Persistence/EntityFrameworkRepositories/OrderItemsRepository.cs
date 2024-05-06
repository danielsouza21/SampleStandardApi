using Microsoft.EntityFrameworkCore;
using SamplePersonalStandard.Core;
using SamplePersonalStandard.Core.Entities;
using SamplePersonalStandard.Core.Repositories;

namespace SamplePersonalStandard.Infrastructure.Persistence.EntityFrameworkRepositories
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class OrderItemsRepository : EntityFrameworkRepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteManyByOrderId(Guid orderId)
        {
            var ordersToDelete = await _dbSet.Where(r => r.OrderId == orderId).ToListAsync();

            if (ordersToDelete != null && ordersToDelete.Count != 0)
            {
                _dbSet.RemoveRange(ordersToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task InsertManyAsync(IEnumerable<OrderItem> orderItems)
        {
            await _dbSet.AddRangeAsync(orderItems);
            await _dbContext.SaveChangesAsync();
        }
    }
}