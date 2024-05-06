using SamplePersonalStandard.Core.BuildingBlocks;

namespace SamplePersonalStandard.Core.ValueObjects
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class Amount : ValueObject
    {
        public decimal Value { get; }

        public Amount(decimal value)
        {
            if (value is < 0 or > 1000000)
            {
                throw new ArgumentException($"Invalid value {value}", nameof(value));
            }

            Value = value;
        }

        public static implicit operator Amount(decimal value) => new(value);

        public static implicit operator decimal(Amount value) => value.Value;

        public static Amount operator +(Amount x, Amount y) => x.Value + y.Value;

        public static Amount operator -(Amount x, Amount y) => x.Value - y.Value;
    }
}
