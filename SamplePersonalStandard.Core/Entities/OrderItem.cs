using SamplePersonalStandard.Core.BuildingBlocks;
using SamplePersonalStandard.Core.ValueObjects;

namespace SamplePersonalStandard.Core.Entities
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class OrderItem : IEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid OrderId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public Amount UnitPrice { get; private set; }
        public Amount Price { get; private set; }

        private OrderItem() { }

        public OrderItem(Guid orderId, string name, int quantity, Amount unitPrice)
        {
            Id = Guid.NewGuid();

            OrderId = orderId;
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Price = quantity * unitPrice;
        }
    }
}
