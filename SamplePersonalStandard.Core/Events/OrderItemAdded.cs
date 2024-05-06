using SamplePersonalStandard.Core.BuildingBlocks;
using SamplePersonalStandard.Core.Entities;

namespace SamplePersonalStandard.Core.Events
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class OrderItemAdded : IDomainEvent
    {
        public OrderItem OrderItem { get; }

        public OrderItemAdded(OrderItem orderItem)
            => OrderItem = orderItem;
    }
}
