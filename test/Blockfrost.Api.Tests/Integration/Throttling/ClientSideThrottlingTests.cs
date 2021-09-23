using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockfrost.Api.Tests.Attributes;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Integration.Throttling
{
    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Integration))]
    [TestCategory(nameof(Throttling))]
    public class ClientSideThrottlingTests : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        [TestMethod]
        public async Task RequestThrottling_550Requests_NoRequestRejectedByServer()
        {
            // After 500 requests the burst limit is reached.
            // The next 50 requests need to be throttled, otherwise the server will return an error.
            int requestCount = 550;
            var results = new Dictionary<int, bool>();

            foreach (int requestNr in Enumerable.Range(1, requestCount))
            {
                try
                {
                    // If the rate limit is reached, this will throw an exception.
                    _ = await HealthService.GetApiInfoAsync();
                    results.Add(requestNr, true);
                }
                catch (Exception)
                {
                    results.Add(requestNr, false);
                }
            }

            Assert.IsTrue(results.All(r => r.Value));
        }

        [TestMethod]
        public async Task RequestThrottling_550Requests_CommonMethods()
        {
            // After 500 requests the burst limit is reached.
            // The next 50 requests need to be throttled, otherwise the server will return an error.
            int requestCount = 550 / 2;
            var results = new Dictionary<int, bool>();

            foreach (int requestNr in Enumerable.Range(1, requestCount))
            {
                try
                {
                    // If the rate limit is reached, this will throw an exception.
                    _ = await AccountsService.Health.GetApiInfoAsync();
                    _ = await AccountsService.Metrics.GetEndpointsAsync();
                    results.Add(requestNr, true);
                }
                catch (Exception)
                {
                    results.Add(requestNr, false);
                }
            }

            Assert.IsTrue(results.All(r => r.Value));
        }
    }
}
