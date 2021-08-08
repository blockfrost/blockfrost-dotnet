using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    [TestClass]
    public abstract class BlockfrostServiceTestsBase
    {
        protected static IConfiguration configuration;
        protected static IBlockfrostService _service;

        [TestMethod]
        public async Task CheckHealth()
        {
            var response = await _service.GetHealthAsync();
            Assert.IsTrue(response.IsHealthy);
        }

        [TestMethod]
        public async Task ClockTest()
        {
            var response = await _service.GetClockAsync();
            Assert.AreNotEqual(0, response.ServerTime);
        }


        [TestMethod]
        public async Task GetLatestBlockAsync()
        {
            var response = await _service.GetLatestBlockAsync();
            Assert.AreNotEqual(0, response.Epoch);
        }

        [TestMethod]
        public async Task GetMetricsAsync()
        {
            var response = await _service.GetMetricsAsync();
            Assert.AreNotEqual(0, response.Count);
        }

        [TestMethod]
        public virtual async Task GetAddress(string address)
        {

        }

        protected static void SetupEnvironment(string projectName)
        {

            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";
            //Determines the working environment as IHostingEnvironment is unavailable in a console app

            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //only add secrets in development
            if (isDevelopment)
            {
                builder.AddUserSecrets<TestnetServiceTests>();
            }

            configuration = builder.Build();
            _service = GetService(projectName);

            IServiceCollection services = new ServiceCollection();

            services.AddBlockfrost(projectName, configuration);

            var provider = services.BuildServiceProvider();
            _service = provider.GetRequiredService<IBlockfrostService>();
        }
        private static IBlockfrostService GetService(string projectName)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddBlockfrost(projectName, configuration);

            var provider = services.BuildServiceProvider();
            _service = provider.GetRequiredService<IBlockfrostService>();
            return _service;
        }

    }
}