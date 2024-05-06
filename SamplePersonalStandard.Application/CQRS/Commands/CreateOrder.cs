using MediatR;
using SamplePersonalStandard.Application.CQRS.Commands.WriteModels;
using SamplePersonalStandard.Core;
using System.ComponentModel.DataAnnotations;

namespace SamplePersonalStandard.Application.CQRS.Commands
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public record CreateOrder([Required] Guid BuyerId, [Required] AddressWriteModel ShippingAddress, [Required] IEnumerable<OrderItemWriteModel> Items) : IRequest<Unit>
    {
    }
}
