using SamplePersonalStandard.Application.CQRS.Commands.WriteModels;
using SamplePersonalStandard.Core;
using SamplePersonalStandard.Core.Entities;
using SamplePersonalStandard.Core.ValueObjects;

namespace SamplePersonalStandard.Application.CQRS.Commands
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public static class Extensions
    {
        public static IEnumerable<OrderItem> AsEntities(this IEnumerable<OrderItemWriteModel> orderItems, Guid orderId)
            => orderItems.Select(orderItem => new OrderItem(orderId, orderItem.Name, orderItem.Quantity, orderItem.UnitPrice));

        public static Address AsValueObject(this AddressWriteModel address, Guid orderId)
            => address is null
                ? null
                : new Address(orderId, address.City, address.Street, address.Province, address.Country, address.ZipCode);
    }
}
