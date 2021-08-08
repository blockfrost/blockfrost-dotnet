using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace Blockfrost.Api.Extensions
{
    public static class BlockfrostExtensions
    {

        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string network, string apiKey)
        {
            services.AddScoped(_ => new BlockfrostAuthorizationHandler(apiKey));
            services
                .AddHttpClient<BlockfrostService>(client => ConfigureHttpClient(network, client))
                .AddHttpMessageHandler<BlockfrostAuthorizationHandler>();
            
            return services;
        }

        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string projectName, IConfiguration configuration)
        {
            services.AddScoped(provider => {
                var options = provider.GetService<IOptions<BlockfrostOptions>>();
                return new BlockfrostAuthorizationHandler(options.Value[projectName].ApiKey);
            });

            services.Configure<BlockfrostOptions>(configuration.GetSection("Blockfrost"));
                        
            services
                .AddHttpClient<BlockfrostService>(projectName, (provider, client) =>
                {
                    var options = provider.GetService<IOptions<BlockfrostOptions>>().Value;
                    ConfigureHttpClient(options[projectName].Network, client);
                })
                .AddHttpMessageHandler<BlockfrostAuthorizationHandler>();
            
            return services;
        }
        
        private static void ConfigureHttpClient(string network, HttpClient client)
        {
            switch (network)
            {
                case "testnet":
                    client.BaseAddress = new Uri("https://cardano-testnet.blockfrost.io/api/v0/");
                    break;
                case "mainnet":
                    client.BaseAddress = new Uri("https://cardano-mainnet.blockfrost.io/api/v0/");
                    break;
                case "ipfs":
                    client.BaseAddress = new Uri("https://ipfs.blockfrost.io/api/v0/");
                    break;
                default:
                    throw new NotSupportedException($"The specified network '{network}' is not supported");
            }
        }
    }
}
