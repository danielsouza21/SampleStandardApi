using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SamplePersonalStandard.Application
{
    public static class ConfigurationExtensions
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ConfigurationExtensions).Assembly));
        }
    }
}
