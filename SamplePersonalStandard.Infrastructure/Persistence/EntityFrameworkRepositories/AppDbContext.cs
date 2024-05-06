using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamplePersonalStandard.Core.Aggregates;
using SamplePersonalStandard.Core.Entities;
using SamplePersonalStandard.Core.ValueObjects;

namespace SamplePersonalStandard.Infrastructure.Persistence.EntityFrameworkRepositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //TODO [Template]: DELETE IT {TEMPLATE}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithOne()
                .HasForeignKey<Order>(o => o.ShippingAddressId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Buyer)
                .WithOne()
                .HasForeignKey<Order>(o => o.BuyerId);

            modelBuilder.Entity<Order>().Ignore(o => o.TotalPrice);

            modelBuilder.Entity<OrderItem>()
                .OwnsOne(o => o.UnitPrice, amount =>
                {
                    amount.Property(a => a.Value);
                });

            modelBuilder.Entity<OrderItem>()
                .OwnsOne(o => o.Price, amount =>
                {
                    amount.Property(a => a.Value);
                });

            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<OrderItem>().HasKey(oi => oi.Id);
            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            modelBuilder.Entity<Buyer>().HasKey(b => b.Id);

            base.OnModelCreating(modelBuilder);
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void UseValueConverterForType<T, TProperty>(
            this ModelBuilder modelBuilder,
            Func<T, TProperty> converterToDatabase,
            Func<TProperty, T> converterFromDatabase)
        {
            // Find all properties of type T and configure value converter
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(T))
                    {
                        property.SetValueConverter(new ValueConverter<T, TProperty>(
                            v => converterToDatabase(v),
                            v => converterFromDatabase(v)));
                    }
                }
            }
        }
    }
}
