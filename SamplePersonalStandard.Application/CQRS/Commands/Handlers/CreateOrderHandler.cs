using MediatR;
using Microsoft.Extensions.Logging;
using SamplePersonalStandard.Application.Exceptions.Custom;
using SamplePersonalStandard.Core.Aggregates;
using SamplePersonalStandard.Core.Repositories;
using SamplePersonalStandard.Core.TypesEnums;

namespace SamplePersonalStandard.Application.CQRS.Commands.Handlers
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class CreateOrderHandler : IRequestHandler<CreateOrder, Unit>
    {
        private readonly IShoppingUnitOfWork _shoppingUoW;
        private readonly ILogger<CreateOrderHandler> _logger;

        public CreateOrderHandler(IShoppingUnitOfWork shoppingUoW, ILogger<CreateOrderHandler> logger)
        {
            _shoppingUoW = shoppingUoW;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateOrder command, CancellationToken cancellationToken)
        {
            var order = await _shoppingUoW.OrderRepository.GetAsync(whereCondition: x => x.BuyerId == command.BuyerId && x.Status != OrderStatus.Pending);

            if (order is not null)
            {
                throw new OrderAlreadyExistsException(order.Id);
            }

            var newOrder = new Order(command.Items.AsEntities(order.Id), OrderStatus.Pending, buyerId: command.BuyerId);
            await _shoppingUoW.CreateOrderAsync(newOrder, command.ShippingAddress.AsValueObject(order.Id), command.Items.AsEntities(order.Id), command.BuyerId);

            return Unit.Value;
        }
    }
}
