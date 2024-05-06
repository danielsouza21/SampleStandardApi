namespace SamplePersonalStandard.Core.Exceptions
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class InvalidOrderStatusException(string status) : DomainException($"Order status is invalid: '{status}'.")
    {
        public string Status { get; } = status;

        /*
            public InvalidOrderStatusException(string status)
            : base($"Order status is invalid: '{status}'.")
                => Status = status;
        */
    }
}
