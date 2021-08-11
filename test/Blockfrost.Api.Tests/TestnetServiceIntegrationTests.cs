using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    [IgnoreAllIf("staging")]
    public class TestnetServiceIntegrationTests : BlockfrostServiceIntegrationTestsBase
    {
        private const string addr_test = "addr_test1qzxug2wcch4gqu6squcx4ffuhsppvrsk7edxv0y0uwqn0xvtcm6l3yfqa9j7swygrgh2k2g7kd7jgvkwxkew2uclhssqgp9f83";
        private const string stake_test = "stake_test1uz9uda0cjyswje0g8zyp5t4t9y0txlfyxt8rtvh9wv0mcgqphtf6d";

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            SetupEnvironment("Blockfrost.Net.Sdk-testnet");
        }

        [TestInitialize]
        public void PassInStagingEnvironment()
        {
        }

        [TestMethod]
        [DataRow(addr_test)]
        public override async Task GetAddressTest(string address)
        {
            await base.GetAddressTest(address);
        }

        [TestMethod]
        [DataRow(addr_test, stake_test)]
        public override async Task GetStakeAddressTest(string paymentAddress, string stakeAddress)
        {
            await base.GetStakeAddressTest(paymentAddress, stakeAddress);
        }

        [TestMethod]
        [DataRow(addr_test, EAddressType.Shelley)]
        public override async Task GetAddressEraTest(string paymentAddress, EAddressType era)
        {
            await base.GetAddressEraTest(paymentAddress, era);
        }
    }
}
