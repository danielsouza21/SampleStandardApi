using SamplePersonalStandard.Core;
using SamplePersonalStandard.Core.Entities;
using SamplePersonalStandard.Core.Repositories;

namespace SamplePersonalStandard.Infrastructure.Persistence.EntityFrameworkRepositories
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class BuyersRepository : EntityFrameworkRepositoryBase<Buyer>, IBuyerRepository
    {
        public BuyersRepository(AppDbContext context) : base(context)
        {
        }
    }
}