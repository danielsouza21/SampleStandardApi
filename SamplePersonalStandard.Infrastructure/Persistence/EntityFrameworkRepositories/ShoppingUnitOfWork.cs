using SamplePersonalStandard.Core;
using SamplePersonalStandard.Core.Aggregates;
using SamplePersonalStandard.Core.Entities;
using SamplePersonalStandard.Core.Repositories;
using SamplePersonalStandard.Core.ValueObjects;

namespace SamplePersonalStandard.Infrastructure.Persistence.EntityFrameworkRepositories
{
    //TODO [Template]: DELETE IT {TEMPLATE}
    public class ShoppingUnitOfWork : IShoppingUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed = false;

        public ShoppingUnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, object>
            {
                { typeof(Buyer), new BuyersRepository(_dbContext) },
                { typeof(Order), new OrdersRepository(_dbContext) },
                { typeof(OrderItem), new OrderItemsRepository(_dbContext) },
                { typeof(Address), new AddressesRepository(_dbContext) }
            };
        }

        #region Repositories

        public IBuyerRepository Buyer => (IBuyerRepository)_repositories[typeof(Buyer)];

        public IOrderRepository OrderRepository => (IOrderRepository)_repositories[typeof(Order)];

        public IOrderItemRepository OrderItemRepository => (IOrderItemRepository)_repositories[typeof(OrderItem)];

        public IAddressRepository AddressRepository => (IAddressRepository)_repositories[typeof(Address)];

        #endregion

        public async Task CreateOrderAsync(Order order, Address address, IEnumerable<OrderItem> items, Guid buyerId)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                await OrderItemRepository.InsertManyAsync(items);
                await AddressRepository.InsertOneAsync(address);

                order.ShippingAddressId = address.Id;

                await OrderRepository.InsertOneAsync(order);

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public async Task UpdateOrderAsync(Order order, Address address, IEnumerable<OrderItem> items)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                await OrderItemRepository.DeleteManyByOrderId(order.Id);

                await OrderItemRepository.InsertManyAsync(items);
                await AddressRepository.InsertOneAsync(address);

                order.ShippingAddressId = address.Id;

                await OrderRepository.UpdateOneAsync(order);

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                transaction.Rollback(); //TODO: testar rollback
            }
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                _disposed = true;
            }
        }

        #endregion
    }
}
