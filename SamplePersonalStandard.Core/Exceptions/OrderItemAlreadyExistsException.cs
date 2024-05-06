namespace SamplePersonalStandard.Core.Exceptions
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class OrderItemAlreadyExistsException : DomainException
    {
        public Guid OrderItemId { get; }

        public OrderItemAlreadyExistsException(Guid orderItemId)
            : base($"Order item with ID: {orderItemId} already exists.")
                => OrderItemId = orderItemId;
    }
}
