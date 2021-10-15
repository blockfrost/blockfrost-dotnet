using Microsoft.Extensions.DependencyInjection;

namespace Blockfrost.Extensions.AzureKeyVault
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string azureSecretName)
        {
            return services;
        }
    }
}
