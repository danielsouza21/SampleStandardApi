namespace SamplePersonalStandard.Core.Exceptions
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class EmptyOrderItemsException : DomainException
    {
        public EmptyOrderItemsException()
            : base($"Empty order items defined for order") { }
    }
}
