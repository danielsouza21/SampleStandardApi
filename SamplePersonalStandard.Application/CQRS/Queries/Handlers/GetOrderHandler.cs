using MediatR;
using SamplePersonalStandard.Core.Aggregates;
using SamplePersonalStandard.Core.Repositories;
using SamplePersonalStandard.Core.TypesEnums;

namespace SamplePersonalStandard.Application.CQRS.Queries.Handlers
{
    public class GetOrderHandler : IRequestHandler<GetOrder, Order>
    {
        private readonly IShoppingUnitOfWork _shoppingUoW;

        public GetOrderHandler(IShoppingUnitOfWork shoppingUoW)
        {
            _shoppingUoW = shoppingUoW;
        }

        public async Task<Order> Handle(GetOrder request, CancellationToken cancellationToken)
        {
            return await _shoppingUoW.OrderRepository.GetAsync(whereCondition: x => x.Id == request.Id);
        }
    }
}
