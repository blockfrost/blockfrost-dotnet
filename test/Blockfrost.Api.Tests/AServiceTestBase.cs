using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    [TestClass]
    public abstract class AServiceTestBase : IBlockfrostService
    {
        protected static IServiceProvider _provider;
        protected static IConfiguration configuration;
        public static IEnumerable<Type> AvailableServiceTypes => Assembly.GetAssembly(typeof(IBlockfrostService)).GetTypes().Where(t => t == typeof(IBlockfrostService));
        public string BaseUrl => Constants.API_URL;
        public string Network { get; }
        public bool ReadResponseAsString { get; set; }

        protected static CancellationToken EmptyToken => CancellationToken.None;

        protected IBlockfrostService Service => _provider.GetRequiredService<IBlockfrostService>();

        public Task<ICollection<MetricsEndpointResponse>> EndpointsAsync()
        {
            return Service.EndpointsAsync();
        }

        public Task<ICollection<MetricsEndpointResponse>> EndpointsAsync(CancellationToken cancellationToken)
        {
            return Service.EndpointsAsync(cancellationToken);
        }

        public Task<ClockResponse> GetClockAsync()
        {
            return Service.GetClockAsync();
        }

        public Task<ClockResponse> GetClockAsync(CancellationToken cancellationToken)
        {
            return Service.GetClockAsync(cancellationToken);
        }

        public Task<HealthResponse> GetHealthAsync()
        {
            return Service.GetHealthAsync();
        }

        public Task<HealthResponse> GetHealthAsync(CancellationToken cancellationToken)
        {
            return Service.GetHealthAsync(cancellationToken);
        }

        public Task<InfoResponse> GetInfoAsync()
        {
            return Service.GetInfoAsync();
        }

        public Task<InfoResponse> GetInfoAsync(CancellationToken cancellationToken)
        {
            return Service.GetInfoAsync(cancellationToken);
        }

        public Task<ICollection<MetricResponse>> GetMetricsAsync()
        {
            return Service.GetMetricsAsync();
        }

        public Task<ICollection<MetricResponse>> GetMetricsAsync(CancellationToken cancellationToken)
        {
            return Service.GetMetricsAsync(cancellationToken);
        }

        protected static void AssertServiceNetworkConfigured<TService>(string projectName, IConfiguration config, IServiceCollection services)
            where TService : IBlockfrostService
        {
            var provider = services.BuildServiceProvider();
            var service = provider.GetRequiredService<TService>();
            Assert.AreEqual(service.Network, config[$"Blockfrost:{projectName}:Network"]);
        }

        protected static void AssertServiceNetworkConfigured(string projectName, Type serviceType, IConfiguration config, IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var service = (IBlockfrostService)provider.GetRequiredService(serviceType);
            Assert.AreEqual(service.Network, config[$"Blockfrost:{projectName}:Network"]);
        }

        protected static void AssertServiceNotConfigured<TService>(IServiceCollection services)
    where TService : IBlockfrostService
        {
            AssertServiceNotConfigured(services, typeof(TService));
        }

        protected static void AssertServiceNotConfigured(IServiceCollection services, Type type)
        {
            Assert.IsFalse(services.Any(t => t.ServiceType == type));
        }

        protected static void SetupEnvironment(string projectName)
        {
            //Determines the working environment as IHostingEnvironment is unavailable in a console app
            var builder = new ConfigurationBuilder();

            // tell the builder to look for the appsettings.json file
            builder
                .AddEnvironmentVariables()
                .AddJsonFile(Constants.APPSETTINGS_FILENAME, optional: false, reloadOnChange: true);

            //only add secrets in development
            var env = Environment.GetEnvironmentVariable(Constants.NETCORE_ENVIRONMENT);

            var isDevelopment = string.IsNullOrEmpty(env) || env.ToLower() == "development";

            if (isDevelopment)
            {
                builder.AddUserSecrets<TestnetServiceIntegrationTests>();
            }

            configuration = builder.Build();

            var apiKey = configuration[$"Blockfrost:{projectName}:ApiKey"] ?? configuration[Constants.BFCLI_API_KEY];
            var network = configuration[$"Blockfrost:{projectName}:Network"] ?? configuration[Constants.BFCLI_NETWORK];

            _provider = new ServiceCollection()
                .AddBlockfrost(network, apiKey)
                .BuildServiceProvider();
        }
    }
}
