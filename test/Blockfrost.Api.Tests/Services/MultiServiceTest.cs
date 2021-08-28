// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public class MultiServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        [TestMethod]
        public async Task TestNamedClients()
        {
            await foreach (var httpClient in GetClientsAsync())
            {
                Assert.AreEqual(ServiceLifetime.Transient, httpClient.Lifetime);
            }
        }

        [TestMethod]
        public void GetTwoDistinctServices()
        {
            try
            {
                _ = Assert.ThrowsException<InvalidOperationException>(() => Provider.GetRequiredService<ITransactionService>());
                Assert.Fail("The Provider could not get the required service");
            }
            catch (AssertFailedException)
            {
                // worked as expected
            }

            try
            {
                // This does not work when registering the Handlers as Singleton
                var addressService = Provider.GetRequiredService<IAddressService>();
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public async Task CallEndpointsFromMultipleServices()
        {
            try
            {
                var transactionService = Provider.GetRequiredService<ITransactionService>();
                var addressService = Provider.GetRequiredService<IAddressService>();

                _ = await transactionService.EndpointsAsync();
                _ = await addressService.EndpointsAsync();
            }
            catch (Exception ex)
            {
                // worked as expected
                Assert.Fail(ex.Message);
            }
        }
    }
}
