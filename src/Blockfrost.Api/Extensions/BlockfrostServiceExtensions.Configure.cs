﻿using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using Blockfrost.Api.Http;
using Blockfrost.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Blockfrost.Api.Extensions
{
    public static partial class BlockfrostServiceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="projectName"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureBlockfrost(this IServiceCollection services, string projectName, IConfiguration configuration)
        {
            if (!services.Any(s => s.ServiceType.FullName.Contains(typeof(IOptions<BlockfrostOptions>).Name)))
            {
                var blockfrostSection = configuration.GetSection($"Blockfrost");
                _ = services.Configure<BlockfrostOptions>(blockfrostSection);

                var project = blockfrostSection.Get<BlockfrostProject>();

                if (string.IsNullOrEmpty(project.Name))
                {
                    project = blockfrostSection.GetProject(projectName);
                }

                if (!projectName.Equals(project.Name, StringComparison.Ordinal))
                {
                    throw new InvalidOperationException($"The specified project '{projectName}' is not configured in the 'Blockfrost' section of the appsettings");
                }

                if (string.IsNullOrEmpty(project.Name))
                {
                    project.Name = projectName;
                }

                if (string.IsNullOrEmpty(project.ApiKey))
                {
                    project.ApiKey = Environment.GetEnvironmentVariable(Constants.ENV_BFCLI_API_KEY);
                }

                if (string.IsNullOrEmpty(project.Network))
                {
                    project.Network = Environment.GetEnvironmentVariable(Constants.ENV_BFCLI_NETWORK);
                }

                services.TryAddSingleton(project);
            }

            services.TryAddSingleton<BlockfrostAuthorizationHandler>();
            services.TryAddSingleton<RequestThrottler>();
            return services;
        }

        /// <summary>
        /// Helper to configure the BaseAddress of the HttpClient used in the BlockfrostService
        /// TODO: Extract to IBlockfrostHttpClientFactory
        /// </summary>
        /// <param name="client"></param>
        /// <param name="network"></param>
        private static void ConfigureHttpClient(HttpClient client, string network, int sockets)
        {
            client.DefaultRequestHeaders.Add($"User-Agent", $"blockfrost-dotnet / v0.1.0 {network}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            if (sockets > Constants.CONNECTION_LIMIT)
            {
                sockets = Constants.CONNECTION_LIMIT;
            }

            client.BaseAddress = network switch
            {
                "testnet" => new Uri(Constants.API_URL_TESTNET),
                "mainnet" => new Uri(Constants.API_URL_MAINNET),
                "preprod" => new Uri(Constants.API_URL_PREPROD),
                "preview" => new Uri(Constants.API_URL_PREVIEW),
                "ipfs" => new Uri(Constants.API_URL_IPFS),
                _ => throw new NotSupportedException($"The specified network '{network}' is not supported"),
            };
            ServicePointManager.FindServicePoint(address: client.BaseAddress).ConnectionLimit = sockets;
        }

        public static void ConfigureBlockfrost(this IServiceCollection services, BlockfrostProject project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (string.IsNullOrEmpty(project.Name))
            {
                throw new InvalidOperationException($"{nameof(project.Name)} must not be null or empty.");
            }

            if (int.Parse(project.ConnectionLimit, NumberStyles.Integer, CultureInfo.InvariantCulture) > Constants.CONNECTION_LIMIT)
            {
                project.ConnectionLimit = $"{Constants.CONNECTION_LIMIT}";
            }

            services.TryAddSingleton(project);
            services.TryAddSingleton<BlockfrostAuthorizationHandler>();
            services.TryAddSingleton<RequestThrottler>();

            _ = services
                .AddOptions<BlockfrostOptions>()
                .Configure<BlockfrostProject>((projects, project) =>
                {
                    projects.Add(project.Name, project);
                });
        }

        public static void ConfigureBlockfrost(this IServiceCollection services, string network, string apiKey, string projectName, int connectionLimit = Constants.CONNECTION_LIMIT)
        {
            var project = new BlockfrostProject()
            {
                ApiKey = apiKey,
                ConnectionLimit = $"{connectionLimit}",
                Name = projectName,
                Network = network
            };

            services.ConfigureBlockfrost(project);
        }
    }
}
