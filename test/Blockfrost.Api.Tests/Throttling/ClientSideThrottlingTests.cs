using Blockfrost.Api.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests.Throttling
{
    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Blockfrost.Api))]
    [TestCategory(nameof(Blockfrost.Api.Tests.Throttling))]
    public class ClientSideThrottlingTests : AServiceTestBase
    {
        private static int _limitCount = 5;
        private static TimeSpan _limitTime = TimeSpan.FromSeconds(2);

        [ClassInitialize]
        public static void Setup(TestContext context) 
        {
            InitializeEnvironment();
        }

        [TestMethod]
        public async Task TestRateLimit()
        {
            // Arrange
            var number_of_requests = 30;
            var then = DateTime.UtcNow;
            // since we expect 10 requests per second and we send 30 we ecpect
            // => 10 requests in the 0th second
            // => 10 requests in the 1st second
            // => 10 requests in the 2nd second
            var minRuntimeSeconds = (number_of_requests - _limitCount) / _limitCount;
            var minRuntime = TimeSpan.FromSeconds(minRuntimeSeconds);

            Dictionary<int, bool> results = new Dictionary<int, bool>();

            // Act
            foreach (var requestNr in Enumerable.Range(1, number_of_requests))
            {
                try
                {
                    await __service.EndpointsAsync();
                    results.Add(requestNr, true);
                }
                catch (Exception ex)
                {
                    results.Add(requestNr, false);
                }
            }


            Assert.IsTrue(results.All(r => r.Value));
        }

        [TestMethod]
        public async Task TestRateLimit100()
        {
            // Arrange
            var number_of_requests = 100;
            // since we expect 10 requests per second and we send 30 we ecpect
            // => 10 requests in the 0th second
            // => 10 requests in the 1st second
            // => 10 requests in the 2nd second
            var minRuntimeSeconds = (number_of_requests - _limitCount) / _limitCount;
            var minRuntime = TimeSpan.FromSeconds(minRuntimeSeconds);

            var then = DateTime.UtcNow;

            Dictionary<int,bool> results = new Dictionary<int, bool>();

            // Act
            foreach (var requestNr in Enumerable.Range(1, number_of_requests))
            {
                try
                {
                    await __service.EndpointsAsync();
                    results.Add(requestNr, true);
                }
                catch (Exception ex)
                {
                    results.Add(requestNr, false);
                }
            }


            Assert.IsTrue(results.All(r => r.Value));
        }

        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
            ConfigureServicesFromConfig(serviceCollection, Constants.PROJECT_NAME_TESTNET);
        }

        /// <summary>
        /// Replaces the default RateLimitHandler
        /// </summary>
        /// <param name="serviceCollection"></param>
        protected override void OnBuildServiceProvider(IServiceCollection serviceCollection)
        {
            var serviceDescriptor = serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(RateLimitHandler));
            serviceCollection.Remove(serviceDescriptor);
            serviceCollection.AddSingleton(new RateLimitHandler(_limitCount, _limitTime));
        }
    }
}
