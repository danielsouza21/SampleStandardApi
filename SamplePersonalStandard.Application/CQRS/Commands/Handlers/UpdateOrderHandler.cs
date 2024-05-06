using MediatR;
using Microsoft.Extensions.Logging;
using SamplePersonalStandard.Application.Exceptions;
using SamplePersonalStandard.Application.Exceptions.Custom;
using SamplePersonalStandard.Core;
using SamplePersonalStandard.Core.Aggregates;
using SamplePersonalStandard.Core.Exceptions;
using SamplePersonalStandard.Core.Repositories;
using SamplePersonalStandard.Core.TypesEnums;

namespace SamplePersonalStandard.Application.CQRS.Commands.Handlers
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class UpdateOrderHandler : IRequestHandler<UpdateOrder, Unit>
    {
        private readonly IShoppingUnitOfWork _shoppingUoW;
        private readonly ILogger<UpdateOrderHandler> _logger;

        public UpdateOrderHandler(IShoppingUnitOfWork shoppingUoW, ILogger<UpdateOrderHandler> logger)
        {
            _shoppingUoW = shoppingUoW;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOrder command, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<OrderStatus>(command.Status, true, out var status))
            {
                throw new InvalidOrderStatusException(command.Status);
            }

            var newOrder = new Order(command.Items.AsEntities(command.Id), status, orderId: command.Id);
            await _shoppingUoW.UpdateOrderAsync(newOrder, command.ShippingAddress.AsValueObject(command.Id), command.Items.AsEntities(command.Id));

            return Unit.Value;
        }
    }
}
