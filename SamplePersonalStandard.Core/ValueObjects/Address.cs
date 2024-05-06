using SamplePersonalStandard.Core.BuildingBlocks;

namespace SamplePersonalStandard.Core.ValueObjects
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class Address : ValueObject, IEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid OrderId { get; private set; } = Guid.NewGuid();
        public string City { get; }
        public string Street { get; }
        public string Province { get; }
        public string Country { get; }
        public string ZipCode { get; }

        private Address() { }

        public Address(Guid orderId, string city, string street, string province, string country, string zipcode)
        {
            Id = Guid.NewGuid();

            OrderId = orderId;
            Street = street;
            City = city;
            Province = province;
            Country = country;
            ZipCode = zipcode;
        }
    }
}
