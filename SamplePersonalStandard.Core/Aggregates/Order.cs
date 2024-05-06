using SamplePersonalStandard.Core.BuildingBlocks;
using SamplePersonalStandard.Core.Entities;
using SamplePersonalStandard.Core.Exceptions;
using SamplePersonalStandard.Core.Rules;
using SamplePersonalStandard.Core.TypesEnums;
using SamplePersonalStandard.Core.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamplePersonalStandard.Core.Aggregates
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class Order : AggregateRoot, IEntity
    {
        private ISet<OrderItem> _items = new HashSet<OrderItem>();

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid BuyerId { get; set; } = Guid.NewGuid();
        public Buyer Buyer { get; set; }

        public Guid ShippingAddressId { get; set; } = Guid.NewGuid();
        public Address ShippingAddress { get; set; }

        public OrderStatus Status { get; set; }

        [NotMapped]
        public Amount TotalPrice { get => Items.Sum(item => item.Price); }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<OrderItem> Items
        {
            get { return _items; }
            private set { _items = new HashSet<OrderItem>(value); }
        }

        private Order() { }

        public Order(IEnumerable<OrderItem> orderItems, OrderStatus status, Guid orderId = default, Guid buyerId = default)
        {
            Id = orderId == default ? Guid.NewGuid() : orderId;
            BuyerId = buyerId == default ? Guid.NewGuid() : buyerId;
            Items = orderItems ?? throw new EmptyOrderItemsException();
            Status = status;

            CheckRule(new MinimumAmountOfASingleOrderShouldBeAtLeast10(TotalPrice));
            CheckRule(new AmountOfASingleOrderCannotExceed100k(TotalPrice));
            CreatedAt = DateTime.UtcNow;
        }

        public void AddOrderItem(OrderItem newItem)
        {
            var item = _items.SingleOrDefault(x => x.Id.Equals(newItem.Id));

            if (item is not null)
            {
                throw new OrderItemAlreadyExistsException(newItem.Id);
            }

            _items.Add(newItem);
        }
    }
}
