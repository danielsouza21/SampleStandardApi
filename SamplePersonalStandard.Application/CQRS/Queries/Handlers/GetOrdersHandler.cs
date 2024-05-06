using MediatR;
using SamplePersonalStandard.Core.Aggregates;
using SamplePersonalStandard.Core.Repositories;

namespace SamplePersonalStandard.Application.CQRS.Queries.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrders, IEnumerable<Order>>
    {
        private readonly IShoppingUnitOfWork _shoppingUoW;

        public GetOrdersHandler(IShoppingUnitOfWork shoppingUoW)
        {
            _shoppingUoW = shoppingUoW;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrders command, CancellationToken cancellationToken)
        {
            return await _shoppingUoW.OrderRepository.GetAllAsync();
        }
    }
}
