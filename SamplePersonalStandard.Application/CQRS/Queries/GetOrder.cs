using MediatR;
using SamplePersonalStandard.Core.Aggregates;

namespace SamplePersonalStandard.Application.CQRS.Queries
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class GetOrder : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
