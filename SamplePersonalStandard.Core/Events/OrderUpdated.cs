using SamplePersonalStandard.Core.Aggregates;
using SamplePersonalStandard.Core.BuildingBlocks;

namespace SamplePersonalStandard.Core.Events
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class OrderUpdated : IDomainEvent
    {
        public Order Order { get; }

        public OrderUpdated(Order order)
            => Order = order;
    }
}
