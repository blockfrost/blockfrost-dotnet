using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blockfrost.Extensions.CardanoSharp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCardanoSharp(this IServiceCollection services)
        {
            return services.AddCardanoSharp("appsettings.json");
        }

        public static IServiceCollection AddCardanoSharp(this IServiceCollection services, string configPath)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile(configPath);

            var config = configBuilder.Build();
            services.Configure<CardanoSharpExtensionOptions>(config.GetSection("Blockfrost:Extensions:CardanoSharp"));

            services.AddTransient<ICardanoSharpService, CardanoSharpService>();
            return services;
        }
    }
}
