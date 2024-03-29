﻿using System;
using System.Linq;
using Blockfrost.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blockfrost.Api.Extensions
{
    public static partial class BlockfrostServiceExtensions
    {
        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            return services.AddBlockfrost(config["BFCLI_NETWORK"], config["BFCLI_API_KEY"]);
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection and configures the specified projectName using the provided configuration
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="projectName">The project name to use from the config</param>
        /// <param name="configuration">The configuration</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string projectName, IConfiguration configuration)
        {
            _ = services.ConfigureBlockfrost(projectName, configuration);
            _ = services.AddCardanoServices(projectName);
            _ = services.AddIPFSServices(projectName);
            //_ = services.AddNutlinkServices(projectName);
            return services;
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection and configures the services for the project from the provided configuration
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="projectName">The project name to use from the config</param>
        /// <param name="configuration">The configuration</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, IConfiguration config)
        {
            var blockfrostConfig = config.GetSection("Blockfrost");
            if (blockfrostConfig == null)
            {
                throw new InvalidOperationException("The configuration contains no section named 'Blockfrost'");
            }

            try
            {
                var options = blockfrostConfig.Get<BlockfrostOptions>();
                string name = options.Single().Key;
                return services.AddBlockfrost(name, config);
            }
            catch
            {
                var project = blockfrostConfig.Get<BlockfrostProject>();
                return services.AddBlockfrost(project.Name, config);
            }
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection and configures the services using the provided project
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="project">The project to use</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, BlockfrostProject project)
        {
            services.ConfigureBlockfrost(project);
            _ = services.AddCardanoServices(project.Name);
            return services;
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string network, string apiKey)
        {
            return _ = services.AddBlockfrost(network, apiKey, Constants.CONNECTION_LIMIT);
        }

        /// <summary>
        /// Adds Blockfrost Services to the service collection
        /// </summary>
        /// <param name="services">The IServiceCollection</param>
        /// <param name="network">The network the services will use</param>
        /// <param name="apiKey">The ApiKey used to authenticate</param>
        /// <param name="connectionLimit">The number of connections the services will use.</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockfrost(this IServiceCollection services, string network, string apiKey, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            string projectName = $"blockfrost-{network}-project";

            services.ConfigureBlockfrost(network, apiKey, projectName, connectionLimit);
            _ = services.AddCardanoServices(projectName);
            _ = services.AddIPFSServices(projectName);
            return services;
        }
    }
}
