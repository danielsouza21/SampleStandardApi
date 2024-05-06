namespace SamplePersonalStandard.Application.Exceptions.Custom
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class OrderNotFoundException : NotFoundException
    {
        public Guid OrderId { get; }

        public OrderNotFoundException(Guid orderId)
            : base($"Order with ID: {orderId} not found.")
                => OrderId = orderId;
    }
}
