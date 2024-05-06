using SamplePersonalStandard.Core.Aggregates;
using SamplePersonalStandard.Core.Entities;
using SamplePersonalStandard.Core.ValueObjects;

namespace SamplePersonalStandard.Core.Repositories
{
    public interface IShoppingUnitOfWork : IDisposable
    {
        IBuyerRepository Buyer { get; } //TODO [Template]: DELETE IT {TEMPLATE}
        IOrderRepository OrderRepository { get; } //TODO [Template]: DELETE IT {TEMPLATE}
        IOrderItemRepository OrderItemRepository { get; } //TODO [Template]: DELETE IT {TEMPLATE}
        IAddressRepository AddressRepository { get; } //TODO [Template]: DELETE IT {TEMPLATE}

        Task CreateOrderAsync(Order order, Address address, IEnumerable<OrderItem> items, Guid buyerId);
        Task UpdateOrderAsync(Order order, Address address, IEnumerable<OrderItem> items);
    }
}
