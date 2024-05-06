using MediatR;
using SamplePersonalStandard.Application.DTOs;
using SamplePersonalStandard.Core.Aggregates;

namespace SamplePersonalStandard.Application.CQRS.Queries
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class GetOrders : IRequest<IEnumerable<Order>> { }
}
