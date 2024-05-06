using SamplePersonalStandard.Core.Entities;

namespace SamplePersonalStandard.Core.Repositories
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task InsertManyAsync(IEnumerable<OrderItem> orderItems);
        Task DeleteManyByOrderId(Guid orderId);
    }
}
