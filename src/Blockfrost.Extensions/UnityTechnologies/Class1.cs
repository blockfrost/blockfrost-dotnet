using Microsoft.Extensions.DependencyInjection;

namespace Blockfrost.Extensions
{
    public static class UnityServiceExtensions
    {
        public static IServiceCollection AddUnity(this IServiceCollection services)
        {
            // configure Unity services
            return services;
        }
    }
}
