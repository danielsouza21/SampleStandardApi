using MediatR;
using SamplePersonalStandard.Application.CQRS.Commands.WriteModels;

namespace SamplePersonalStandard.Application.CQRS.Commands
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public record UpdateOrder(Guid Id, AddressWriteModel ShippingAddress, IEnumerable<OrderItemWriteModel> Items, string Status) : IRequest<Unit>;
}
