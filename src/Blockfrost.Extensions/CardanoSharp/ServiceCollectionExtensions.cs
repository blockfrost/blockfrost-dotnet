using CardanoSharp.Wallet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            
            services.AddTransient<IWalletService, WalletService>();
            return services;
        }
    }
}
