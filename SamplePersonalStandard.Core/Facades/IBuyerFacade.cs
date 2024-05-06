using SamplePersonalStandard.Core.Entities;

namespace SamplePersonalStandard.Core.Facades
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public interface IBuyerFacade
    {
        Task InsertBuyerAsync(Buyer buyer);
        Task RetrieveAllOrderForBuyerId(Guid buyerId);
    }
}
