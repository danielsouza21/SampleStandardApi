using SamplePersonalStandard.Core.BuildingBlocks;
using SamplePersonalStandard.Core.ValueObjects;

namespace SamplePersonalStandard.Core.Entities
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class Buyer : IEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Address Address { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Buyer() { }

        public Buyer(Guid id, string firstName, string lastName, string email, Address address, DateTime createdAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            CreatedAt = createdAt;
        }
    }
}
