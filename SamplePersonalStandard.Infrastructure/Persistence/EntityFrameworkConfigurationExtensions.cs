using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SamplePersonalStandard.Core.Repositories;
using SamplePersonalStandard.Infrastructure.Persistence.EntityFrameworkRepositories;

namespace SamplePersonalStandard.Infrastructure.Persistence
{
    public static class EntityFrameworkConfigurationExtensions
    {
        public static void AddEntityFrameworkInfrastructure(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IShoppingUnitOfWork, ShoppingUnitOfWork>();

            services.AddScoped<IOrderRepository, OrdersRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemsRepository>();
            services.AddScoped<IBuyerRepository, BuyersRepository>();
            services.AddScoped<IAddressRepository, AddressesRepository>();
        }
    }
}
