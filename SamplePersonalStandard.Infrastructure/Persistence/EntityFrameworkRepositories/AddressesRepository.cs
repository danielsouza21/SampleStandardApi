using SamplePersonalStandard.Core;
using SamplePersonalStandard.Core.Repositories;
using SamplePersonalStandard.Core.ValueObjects;

namespace SamplePersonalStandard.Infrastructure.Persistence.EntityFrameworkRepositories
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class AddressesRepository : EntityFrameworkRepositoryBase<Address>, IAddressRepository
    {
        public AddressesRepository(AppDbContext context) : base(context)
        {
        }
    }
}