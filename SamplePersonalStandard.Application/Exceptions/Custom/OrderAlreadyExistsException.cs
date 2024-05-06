namespace SamplePersonalStandard.Application.Exceptions.Custom
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class OrderAlreadyExistsException : BadRequestException
    {
        public Guid OrderId { get; }

        public OrderAlreadyExistsException(Guid orderId)
            : base($"Order with Id: {orderId} already exists.")
                => OrderId = orderId;
    }
}
