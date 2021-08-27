// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using Blockfrost.Api.Tests.Attributes;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Integration
{

    [IntegrationTestClass(nameof(Environments.Staging))]
    [TestCategory(nameof(Blockfrost.Api))]
    [TestCategory(nameof(Blockfrost.Api.Tests.Integration))]
    [TestCategory(Constants.NETWORK_MAINNET)]
    public class MainnetServiceTests : AIntegrationTestsBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_MAINNET, context);
        }

        public MainnetServiceTests() : base(Constants.API_VERSION)
        {
        }

        [TestMethod]
        public void Network_Is_Mainnet()
        {
            Assert.AreEqual(Constants.NETWORK_MAINNET, Service.Network);
        }
    }
}
